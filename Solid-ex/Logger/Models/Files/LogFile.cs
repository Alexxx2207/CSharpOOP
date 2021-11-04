using Logger.Common;
using Logger.Interfaces;
using Logger.Models.Enumerations;
using Logger.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Logger.Models.Files
{
    public class LogFile : IFile
    {
        private readonly IPathManager pathManager;

        public LogFile(IPathManager pathManager)
        {
            this.pathManager = pathManager;
            this.pathManager.EnsureDirectoryAndFileExists();
        }

        public string Path => this.pathManager.CurrentFilePath;

        public long Size => CalcFileSize();

        public string Write(ILayout layout, IError error)
        {
            string format = layout.Format;
            DateTime dateTime = error.DateTime;
            string message = error.Message;
            Level level = error.Level;

            string formatMessage = string.Format(format, dateTime.ToString(GlobalConstants.DateTimeFormat), level.ToString(), message);

            return formatMessage;
        }

        private long CalcFileSize()
        {
            string text = File.ReadAllText(this.Path);

            return text.ToCharArray().Sum(char1 => char1);

        }
    }
}
