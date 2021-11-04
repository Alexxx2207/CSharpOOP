using Logger.Models.PathManagement;
using Logger.Models.Interfaces;
using System;
using Logger.Interfaces;
using System.Collections.Generic;
using Logger.Models.Enumerations;
using Logger.IOManagement.Interfaces;
using Logger.Common;
using Logger.Factories;
using Logger.Models.Files;
using Logger.Models;
using Logger.IOManagement;
using Logger.Core;
using Logger.Core.Inderfaces;

namespace Logger
{
    public class StartUp
    {

  

        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            LayoutFactory layoutFactory = new LayoutFactory();
            AppenderFactory appenderFactory = new AppenderFactory();

            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IPathManager pathManager = new PathManager("logs", "logs.txt");

            IFile file = new LogFile(pathManager);

            ILogger logger = BuildLogger(n, reader, writer, file, layoutFactory, appenderFactory);

            IEngine engine = new Engine(logger, reader, writer);
            engine.Run();
        }

        private static ILogger BuildLogger(int appendersCount, IReader reader, IWriter writer, IFile file, LayoutFactory layoutFactory, AppenderFactory appenderFactory)
        {
            ICollection<IAppender> appenders = new HashSet<IAppender>();

            for (int i = 0; i < appendersCount; i++)
            {
                string[] appenderArgs = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string appenderType = appenderArgs[0];
                string layoutType = appenderArgs[1];

                bool hasError = false;
                Level level = ParseLevel(appenderArgs, writer, ref hasError);

                if (hasError)
                {
                    continue;
                }

                try
                {
                    ILayout layout = layoutFactory.CreateLayout(layoutType);
                    IAppender appender = appenderFactory.CreaterAppender(appenderType, layout, level, file);
                    appenders.Add(appender);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            ILogger logger = new LoggerClass(appenders);

            return logger;
        }

        private static Level ParseLevel(string[] levelStr, IWriter writer, ref bool hasError)
        {
            Level appenderLevel = Level.INFO;

            if (levelStr.Length == 3)
            {
                bool isEnumValid = Enum.TryParse(typeof(Level), levelStr[2], true, out object enumParsed);

                if (!isEnumValid)
                {
                    writer.WriteLine(GlobalConstants.INVALID_LEVEL_TYPE);
                    hasError = true;
                }
                else
                {
                    appenderLevel = (Level)enumParsed;
                }
            }

            return appenderLevel;
        }
    }
}
