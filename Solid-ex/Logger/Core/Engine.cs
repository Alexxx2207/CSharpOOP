using Logger.Common;
using Logger.Core.Inderfaces;
using Logger.Factories;
using Logger.Interfaces;
using Logger.IOManagement.Interfaces;
using Logger.Models.Enumerations;
using Logger.Models.Errors;
using Logger.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Logger.Core
{
    class Engine : IEngine
    {
        private readonly ILogger logger;
        private readonly IReader reader;
        private readonly IWriter writer;
        public Engine(ILogger logger, IReader reader,  IWriter writer)
        {
            this.logger = logger;
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {

            string input;

            while ((input = reader.ReadLine()) != "END")
            {
                string[] errorArgs = input.Split("|");

                string levelStr = errorArgs[0];
                string dateTimeStr = errorArgs[1];
                string message = errorArgs[2];

                bool isLevelValid = Enum.TryParse(typeof(Level), levelStr, true, out object levelObj);

                if (!isLevelValid)
                {
                    this.writer.WriteLine(GlobalConstants.INVALID_LEVEL_TYPE);
                }

                Level level = (Level)levelObj;

                bool isDateTimeParsed = DateTime.TryParseExact(dateTimeStr, GlobalConstants.DateTimeFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateTime);


                if (!isDateTimeParsed)
                {
                    this.writer.WriteLine(GlobalConstants.INVALID_DATETIME_FORMAT);
                }

                IError error = new Error(dateTime, message, level);
                this.logger.Log(error);
            }

            writer.WriteLine(this.logger.ToString());
        }
    }
}
