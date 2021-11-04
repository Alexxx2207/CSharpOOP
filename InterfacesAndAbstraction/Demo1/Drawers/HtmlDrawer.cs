using Demo1.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Demo1.Drawers
{
    class HtmlDrawer : IDrawer
    {
        private string path;
        private StringBuilder result;

        public HtmlDrawer(string path)
        {
            this.path = path;
            result = new StringBuilder();
        }

        public void Write(string input)
        {
            result.Append(input);
            using (StreamWriter writer = new StreamWriter(path + ".html", true))
            {
                writer.Write($"<html><head></head><body><h1>Best game!!!</h1><p>{result.ToString().TrimEnd()}</p></body></html>");
            }
        }

        public void WriteLine(string input)
        {
            result.Append(input);
            using (StreamWriter writer = new StreamWriter(path + ".html", true))
            {
                writer.WriteLine($"<html><head></head><body><h1>Best game!!!</h1><p>{result.ToString().TrimEnd()}</p></body></html>");
            }
        }
    }
}
