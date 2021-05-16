using BusyList.Commands;
using BusyList.Handlers;
using BusyList.Parsing;
using Microsoft.Extensions.DependencyInjection;
using Sprache;
using System;

namespace BusyList
{
    public static class Program
    {
        const string PROMPT = "> ";

        private static void Main()
        {
            // Set up the DependencyInjection collection and provider
            var services = ConfigureServices();
            var provider = services.BuildServiceProvider();

            var parser = CommandGrammar.Source;

            InteractiveMode(provider, parser);
        }

        private static void InteractiveMode(ServiceProvider provider, Parser<Command> parser)
        {
            string line;
            do
            {
                Console.Write(PROMPT);
                line = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(line))
                {
                    try
                    {
                        var result = parser.Parse(line);

                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine(result);

                        Console.ResetColor();
                        HandleCommand(provider, result);
                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(ex.Message);
                    }

                    Console.ResetColor();
                    Console.WriteLine();
                }
            }
            while (line != null);
        }

        private static IServiceCollection ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddSingleton<ICommandDispatcher, CommandDispatcher>();

            services.AddTransient<IHandler<AddCommand>, AddHandler>();
            services.AddTransient<IHandler<DeleteCommand>, DeleteHandler>();
            services.AddTransient<IHandler<DoneCommand>, DoneHandler>();
            services.AddTransient<IHandler<NextCommand>, NextHandler>();
            services.AddTransient<IHandler<ReadCommand>, ReadHandler>();

            return services;
        }

        private static void HandleCommand(ServiceProvider provider, Command command)
        {
            var dispatcher = provider.GetRequiredService<ICommandDispatcher>();
            dispatcher.Handle(command);
        }
    }
}
