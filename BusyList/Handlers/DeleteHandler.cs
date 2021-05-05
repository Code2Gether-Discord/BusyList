using BusyList.Commands;
using System;

namespace BusyList.Handlers
{
    internal class DeleteHandler : IHandler<DeleteCommand>
    {
        public void Run(DeleteCommand command)
        {
            Console.WriteLine($"If the DeleteHandler was implemented, I would now delete Task {command.Id}.");
        }
    }
}