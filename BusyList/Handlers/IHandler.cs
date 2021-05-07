using BusyList.Commands;

namespace BusyList.Handlers
{
    internal interface IHandler<in TCommand> where TCommand : Command
    {
        void Run(TCommand command);
    }
}