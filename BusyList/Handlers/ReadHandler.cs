using BusyList.Commands;
using System;

namespace BusyList.Handlers
{
    public class ReadHandler : IHandler<ReadCommand>
    {
        private readonly ITaskRepository _taskRepository;

        public ReadHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public void Run(ReadCommand command)
        {
            var readTask = _taskRepository.GetTaskById(command.Id);
            Console.WriteLine($"If the ReadHandler was implemented, I would now list details for Task {readTask}.");
        }
    }
}