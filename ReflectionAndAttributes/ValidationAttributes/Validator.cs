using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ValidationAttributes
{
    public class Validator
    {
        public static bool IsValid(object obj)
        {
            PropertyInfo[] properties = obj.GetType().GetProperties();

            foreach (PropertyInfo prop in properties)
            {
                IEnumerable<MyValidationAttribute> propCustomAttribute = prop.GetCustomAttributes().Where(x => x is MyValidationAttribute).Cast<MyValidationAttribute>();

                foreach (MyValidationAttribute attr in propCustomAttribute)
                {
                    bool result = attr.IsValid(prop.GetValue(obj));
                    if (!result)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
