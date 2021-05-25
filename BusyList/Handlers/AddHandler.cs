using BusyList.Commands;
using BusyList.HelpSystem;
using System;


namespace BusyList.Handlers
{
    [HelpAttribute("add", "Add a new task with the passed description", "add [Description]")]
    public class AddHandler : IHandler<AddCommand>
    {
        private readonly ITaskRepository _taskRepository;

        public AddHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public void Run(AddCommand command)
        {
            var item = new AddTaskData(command.Description);

            var currentTask = _taskRepository.AddTask(item);

            Console.WriteLine($"Added {currentTask.Print()}");
        }
    }
}
