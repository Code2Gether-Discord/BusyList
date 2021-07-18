using BusyList.Commands;
using BusyList.HelpSystem;
using System;

namespace BusyList.Handlers
{
    public class HelpHandler : IHandler<HelpCommand>
    {
        private readonly HelpProvider _helpProvider;

        public HelpHandler(HelpProvider helpProvider)
        {
            _helpProvider = helpProvider;
        }

        public void Help()
        {
            var helpTexts = _helpProvider.GetAllHelpText();

            foreach (var (name, description) in helpTexts)
            {
                Console.WriteLine($"{name}: {description}");
            }

            Console.WriteLine("For further information type help [keyword] e.g help add");
        }

        public void Run(HelpCommand command)
        {
            if (command.name == null)
            {
                Help();

                return;
            }

            var (description, syntax) = _helpProvider.GetHelpText(command.name);

            if (description != null && syntax != null)
            {
                Console.WriteLine($"Command: {command.name.ToLowerInvariant()}");
                Console.WriteLine($"Description: {description}");
                Console.WriteLine($"Syntax: {syntax}");
            }
            else
            {
                Console.WriteLine($"Help for the command '{command.name.ToLowerInvariant()}' does not exists");
            }
        }
    }
}
