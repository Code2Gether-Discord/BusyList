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
            Console.WriteLine("Commands:\n");
            Console.WriteLine("done - mark a task as done");
            Console.WriteLine("delete - delete a task");
            Console.WriteLine("next - list all tasks");
            Console.WriteLine("read - print the id, description and status of a task\n");
            Console.WriteLine("For more details do: help [keyword] e.g help done");
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
                Console.WriteLine(command.name);
                Console.WriteLine(description);
                Console.WriteLine(syntax);
            }
        }
    }
}
