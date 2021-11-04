using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string RevealPrivateMethods(string className)
        {
            StringBuilder sb = new StringBuilder();

            Type classType = Type.GetType(className);
            MethodInfo[] methodInfos = classType.GetMethods(BindingFlags.NonPublic|BindingFlags.Instance);
            sb.AppendLine($"All Private Methods of Class: {classType.FullName}");
            sb.AppendLine($"Base Class: {classType.BaseType}");
            foreach (var method in methodInfos)
            {
                sb.AppendLine(method.Name);
            }

            return sb.ToString().TrimEnd();
        }

        public string AnalyzeAcessModifiers(string className)
        {
            StringBuilder sb = new StringBuilder();

            Type classType = Type.GetType(className);
            FieldInfo[] fieldInfos = classType.GetFields(BindingFlags.Public|BindingFlags.Instance|BindingFlags.Static);
            MethodInfo[] publicMethodsInfos = classType.GetMethods(BindingFlags.Public | BindingFlags.Instance);
            MethodInfo[] privateMethodsInfos = classType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

            fieldInfos.ToList().ForEach(field => sb.AppendLine($"{field} must be private!"));
            foreach (var method in publicMethodsInfos.Where(m => m.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} have to be private!");
            }
            foreach (var method in privateMethodsInfos.Where(m => m.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} have to be private!");
            }

            return sb.ToString().TrimEnd();
        }

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
