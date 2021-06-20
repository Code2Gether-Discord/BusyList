using BusyList.Commands;
using System;


namespace BusyList.Handlers
{
    public class AddHandler : IHandler<AddCommand>
    {
        private readonly ITaskRepository _taskRepository;

        public AddHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
        public void Run(AddCommand command)
        {
            var item = new AddTaskData(command.Description, command.Priority);

            var currentTask = _taskRepository.AddTask(item);

            Console.WriteLine($"Added {currentTask.Print()}");
        }

    }
}
