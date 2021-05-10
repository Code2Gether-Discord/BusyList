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
            var item = new AddTaskData(command.Description);

            var currentTask = _taskRepository.AddTask(item);

            Print(currentTask);
        }
        private void Print(TaskItem item)
        {
            string changedString = $"Added task #{item.Id} with description: {item.Description}";

            Console.WriteLine(changedString);
        }
    }
}
