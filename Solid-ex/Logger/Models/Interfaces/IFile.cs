using Logger.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Interfaces
{
    public interface IFile
    {
        string Path { get; }
        long Size { get; }

        string Write(ILayout layout, IError error);
    }
}
