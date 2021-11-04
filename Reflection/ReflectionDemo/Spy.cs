using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string classToInvestigate, params string[] fields)
        {
            StringBuilder sb = new StringBuilder();

            Type classType = Type.GetType(classToInvestigate);
            Object classInstance = Activator.CreateInstance(Type.GetType(classToInvestigate), new object[] { });
            sb.AppendLine($"Class under investigation: {classType.FullName}");
            fields.ToList().ForEach(field => sb.AppendLine($"{field} = {classType.GetField(field, BindingFlags.NonPublic|BindingFlags.Static|BindingFlags.Public|BindingFlags.Instance).GetValue(classInstance)}"));

            return sb.ToString().TrimEnd();
        }
    }
}
