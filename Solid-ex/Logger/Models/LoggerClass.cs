using Logger.Interfaces;
using Logger.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Models
{
    public class LoggerClass : ILogger
    {
        private readonly ICollection<IAppender> appenders;

        public LoggerClass(ICollection<IAppender> appenders)
        {
            this.appenders = appenders;
        }

        public LoggerClass(params IAppender[] appenders)
        {
            this.appenders = appenders;
        }

        public IReadOnlyCollection<IAppender> Appenders => (IReadOnlyCollection<IAppender>)appenders;

        public void Log(IError error)
        {
            foreach (var appender in appenders)
            {
                if (error.Level >= appender.Level)
                {
                    appender.Append(error);
                }
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Logger info");
            foreach (var appender in appenders)
            {
                sb.AppendLine(appender.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
