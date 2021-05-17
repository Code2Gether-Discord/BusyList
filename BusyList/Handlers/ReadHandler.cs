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
            var task = _taskRepository.GetTaskById(command.Id);

            if (task == null)
            {
                Console.WriteLine($"The task with the id {command.Id} does not exist");
                return;
            }

            Console.WriteLine(task.Print());
        }
    }
}