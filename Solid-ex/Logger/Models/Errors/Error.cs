using Logger.Models.Enumerations;
using Logger.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Models.Errors
{
    public class Error : IError
    {
        public Error(DateTime dateTime, string message, Level level)
        {
            DateTime = dateTime;
            Message = message;
            Level = level;
        }

        public DateTime DateTime { get; }
        public string Message { get; }
        public Level Level { get; }
    }
}
