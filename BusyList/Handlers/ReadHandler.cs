using BusyList.Commands;
using System;

namespace BusyList.Handlers
{
    internal class ReadHandler : IHandler<ReadCommand>
    {
        public void Run(ReadCommand command)
        {
            Console.WriteLine($"If the ReadHandler was implemented, I would now list details for Task {command.Id}.");
        }
    }
}