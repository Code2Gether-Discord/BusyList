using BusyList.Commands;
using System;

namespace BusyList.Handlers
{
    internal class NextHandler : IHandler<NextCommand>
    {
        public void Run(NextCommand command)
        {
            Console.WriteLine("Hello from the next command!");
        }
    }
}