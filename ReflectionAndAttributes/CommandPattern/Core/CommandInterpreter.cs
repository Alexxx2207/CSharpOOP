using CommandPattern.Core.Commands;
using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] tokens = args.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string commandType = tokens[0].ToLower();
            string[] commandArgs = tokens.Skip(1).ToArray();

            string result = string.Empty;
           

            var type = Assembly.GetCallingAssembly()
                    .GetTypes()
                    .FirstOrDefault(x => x.Name.ToLower() == $"{commandType}Command".ToLower());

            ICommand command = (ICommand)Activator.CreateInstance(type);
            result = command?  .Execute(commandArgs) ?? "Invalid Command";

            return result;
        }
    }
}
