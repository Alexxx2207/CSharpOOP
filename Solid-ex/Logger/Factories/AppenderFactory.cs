using Logger.Common;
using Logger.Interfaces;
using Logger.Models.Appenders;
using Logger.Models.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Factories
{
    public class AppenderFactory
    {
        public AppenderFactory()
        {

        }

        public IAppender CreaterAppender(string appenderType, ILayout layout, Level level, IFile file = null)
        {
            IAppender appender;

            if (appenderType == nameof(ConsoleAppender))
            {
                appender = new ConsoleAppender(layout, level);
            }
            else if(appenderType == nameof(FileAppender) && file != null)
            {
                appender = new FileAppender(layout, level, file);
            }
            else
            {
                throw new InvalidOperationException(GlobalConstants.INVALID_APPENDER_TYPE);
            }

            return appender;
        }
    }
}
