using Logger.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Logger.Models.PathManagement
{
    public class PathManager : IPathManager
    {
        private readonly string currentPath;
        private readonly string folderName;
        private readonly string fileName;

        private PathManager()
        {
            currentPath = GetCurrentPath();
        }
        public PathManager(string folderName, string filename) : this()
        {
            this.folderName = folderName;
            this.fileName = filename;
        }

        public string CurrentDirectoryPath => this.currentPath + "\\" + folderName;

        public string CurrentFilePath => this.currentPath + "\\" + folderName + "\\" + fileName;


        public void EnsureDirectoryAndFileExists()
        {
            if (!Directory.Exists(this.CurrentDirectoryPath))
            {
                Directory.CreateDirectory(CurrentDirectoryPath);
            }

            File.AppendAllText(CurrentFilePath, string.Empty);
        }

        public string GetCurrentPath()
        {
            return Directory.GetCurrentDirectory();
        }
    }
}
