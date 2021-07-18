using BusyList.Commands;

namespace BusyList.Handlers
{
    public interface IHandler<in TCommand> where TCommand : Command
    {
        void Run(TCommand command);
    }
}
