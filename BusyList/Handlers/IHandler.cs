using BusyList.Commands;

namespace BusyList.Handlers
{
    public interface IHandler<in TCommand> where TCommand : Command
    {
        void Run(TCommand command);
        void Help();
    }

    internal interface IHelpHandler
    {
        void Run<TCommand>(IHandler<TCommand> handler) where TCommand : Command;
    }
}
