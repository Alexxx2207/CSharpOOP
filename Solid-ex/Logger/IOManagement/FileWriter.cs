using Logger.IOManagement.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Logger.IOManagement
{
    public class FileWriter : IWriter
    {
        public string FilePath { get; set; }
        public FileWriter(string path)
        {
            FilePath = path;
        }
        public void Write(string text)
        {
            File.AppendAllText(FilePath, text);
        }

        public void WriteLine(string text)
        {
            File.AppendAllText(FilePath, text + Environment.NewLine);

        }
    }
}
