﻿using BusyList.Commands;
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

            services.AddTransient<IHandler<ReadCommand>, ReadHandler>();
            services.AddTransient<IHandler<DeleteCommand>, DeleteHandler>();
            services.AddTransient<IHandler<NextCommand>, NextHandler>();
            services.AddSingleton<IHandler<AddCommand>, AddHandler>();

            return services;
        }

        private static void HandleCommand(ServiceProvider provider, Command command)
        {
            switch (command)
            {
                case ReadCommand read:
                    provider.GetRequiredService<IHandler<ReadCommand>>().Run(read);
                    break;
                case DeleteCommand delete:
                    provider.GetRequiredService<IHandler<DeleteCommand>>().Run(delete);
                    break;
                case NextCommand next:
                    provider.GetRequiredService<IHandler<NextCommand>>().Run(next);
                    break;
                case AddCommand add:
                    provider.GetRequiredService<IHandler<AddCommand>>().Run(add);
                    break;
                default:
                    throw new Exception($"Unknown command type {command.GetType().FullName} sent to HandleCommand!");
            }
        }
    }
}
