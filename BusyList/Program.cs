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

            services.AddSingleton<ITaskRepository, TaskRepository>();
            services.AddTransient<IHandler<AddCommand>, AddHandler>();
            services.AddTransient<IHandler<DeleteCommand>, DeleteHandler>();
            services.AddTransient<IHandler<DoneCommand>, DoneHandler>();
            services.AddTransient<IHandler<NextCommand>, NextHandler>();
            services.AddTransient<IHandler<ReadCommand>, ReadHandler>();

            return services;
        }

        private static void HandleCommand(ServiceProvider provider, Command command)
        {
            switch (command)
            {
                case AddCommand add:
                    provider.GetRequiredService<IHandler<AddCommand>>().Run(add);
                    break;
                case DeleteCommand delete:
                    provider.GetRequiredService<IHandler<DeleteCommand>>().Run(delete);
                    break;
                case DoneCommand done:
                    provider.GetRequiredService<IHandler<DoneCommand>>().Run(done);
                    break;
                case NextCommand next:
                    provider.GetRequiredService<IHandler<NextCommand>>().Run(next);
                    break;
                case ReadCommand read:
                    provider.GetRequiredService<IHandler<ReadCommand>>().Run(read);
                    break;
                default:
                    throw new Exception($"Unknown command type {command.GetType().FullName} sent to HandleCommand!");
            }
        }
    }
}
