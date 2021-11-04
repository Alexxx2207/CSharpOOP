using Logger.Models.Enumerations;
using Logger.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Interfaces
{
    public interface IAppender
    {
        ILayout Layout { get; }
        Level Level { get; }
        void Append(IError error);
    }
}
