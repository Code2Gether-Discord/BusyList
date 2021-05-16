using BusyList.Handlers;
using System;

namespace BusyList.Commands
{
    public interface ICommandDispatcher
    {
        void Handle<T>(in T command) where T : Command;
    }

    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public CommandDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void Handle<T>(in T command) where T : Command
        {
            var handlerType = typeof(IHandler<>).MakeGenericType(command.GetType());
            var handler = _serviceProvider.GetService(handlerType) as IHandler<T>;

            if (handler == null)
            {
                throw new UnregisteredCommandException($"No command handler registered for command of type {typeof(T).FullName}.");
            }

            handler.Run(command);
        }
    }
}
