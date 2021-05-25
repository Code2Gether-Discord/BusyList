using BusyList.Commands;
using BusyList.HelpSystem;
using System;

namespace BusyList.Handlers
{
    [HelpAttribute("read", "Print the id, description and status of the task with the passed id", "[Id]")]
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
