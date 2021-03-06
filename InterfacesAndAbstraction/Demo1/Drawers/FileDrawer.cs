using Demo1.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Demo1.Drawers
{
    class FileDrawer : IDrawer
    {
        private string path;

        public FileDrawer(string path)
        {
            this.path = path;
        }

        public void Write(string input)
        {
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.Write(input);
            }
        }

        public void WriteLine(string input)
        {
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(input);
            }
        }
    }
}
