using System;
using ManyConsole;
using System.Collections.Generic;
namespace NasaDownloadImageHost
{
    public static class Program
    {
        static  int Main(string[] args)
        {
            StartUp();

            var commands = GetCommands();

            return ConsoleCommandDispatcher.DispatchCommand(commands, args, Console.Out);

        }
        private static void StartUp()
        {
            
        }

        public static IEnumerable<ConsoleCommand> GetCommands()
        {
            return ConsoleCommandDispatcher.FindCommandsInSameAssemblyAs(typeof(Program));
        }
    }
}
