using Logger.Interfaces;
using Logger.IOManagement;
using Logger.IOManagement.Interfaces;
using Logger.Models.Enumerations;
using Logger.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Models.Appenders
{
    public class FileAppender : IAppender
    {
        private int messagesAppended;

        private IWriter writer;
        public FileAppender(ILayout layout, Level level,IFile file)
        {
            Layout = layout;
            Level = level;
            File = file;

            writer = new FileWriter(file.Path);
        }

        public ILayout Layout { get; }

        public Level Level { get; }
        public IFile File { get; }

        public void Append(IError error)
        {
            string formatted = File.Write(Layout, error);

            writer.WriteLine(formatted);
            messagesAppended++;
        }

        public override string ToString()
        {
            return $"Logger info Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {this.Level.ToString()}, Messages appended: {this.messagesAppended}, File size {this.File.Size}";

        }
    }
}
