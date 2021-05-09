using BusyList.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusyList.Handlers
{
    public class AddHandler : IHandler<AddCommand>
    {
        private ITaskRepository _taskRepository;

        public AddHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
        public void Run(AddCommand command)
        {
            AddTaskData item = new AddTaskData(command.Description);
            _taskRepository.AddTask(item);

            Console.WriteLine($"Added task with description:{item.Description}.");
        }
    }
}
