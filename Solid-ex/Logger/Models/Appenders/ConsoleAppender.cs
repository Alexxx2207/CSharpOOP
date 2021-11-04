using Logger.Common;
using Logger.Interfaces;
using Logger.IOManagement;
using Logger.IOManagement.Interfaces;
using Logger.Models.Enumerations;
using Logger.Models.Interfaces;
using System;
    

namespace Logger.Models.Appenders
{
    public class ConsoleAppender : IAppender
    {
        private int messagesAppended;
        private readonly IWriter writer;

        private ConsoleAppender()
        {
            writer = new ConsoleWriter();
            messagesAppended = 0;
        }
        public ConsoleAppender(ILayout layout, Level level) : this()
        {
            Layout = layout;
            Level = level;
        }

        public ILayout Layout { get; }
        public Level Level { get; }

        public void Append(IError error)
        {
            string format = this.Layout.Format;
            DateTime dateTiem = error.DateTime;
            string messages = error.Message;
            Level level = error.Level;

            string formatted = string.Format(format, dateTiem.ToString(GlobalConstants.DateTimeFormat), level, messages);

            this.writer.WriteLine(formatted);
            this.messagesAppended++;
        }

        public override string ToString()
        {
            return $"Logger info Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {this.Level.ToString()}, Messages appended: {this.messagesAppended}";

        }
    }
}
