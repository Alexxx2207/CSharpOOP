using Logger.Common;
using Logger.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Logger.Factories
{
    public class LayoutFactory
    {
        public LayoutFactory()
        {

        }

        public ILayout CreateLayout(string layoutTypeStr)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type layoutType = assembly.GetTypes().FirstOrDefault(t => t.Name.Equals(layoutTypeStr, StringComparison.InvariantCultureIgnoreCase));

            if (layoutType == null)
            {
                throw new InvalidOperationException(GlobalConstants.INVALID_LAYOUT_TYPE);
            }

            object[] args = new object[] { };
            ILayout layout = (ILayout)Activator.CreateInstance(layoutType, args);

            return layout;
        }
    }
}
