using BusyList.Commands;
using System;
using System.Collections.Generic;

namespace BusyList.Handlers
{
    public class ListHandler : IHandler<DoneCommand>
    {
        private readonly ITaskRepository _taskRepository;

        public ListHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public void Run(DoneCommand command)
        {
            IEnumerable<TaskItem> tasks = _taskRepository.GetAll();

            string seperator = new String('-', 10);

            Console.WriteLine("Tasks:\n");

            foreach (var item in tasks)
            {
                Console.WriteLine(seperator);
                Console.WriteLine($"Task id: {item.Id}");
                Console.WriteLine($"Description: {item.Description}");
                Console.WriteLine($"Status: {item.TaskStatus}");
                Console.WriteLine(seperator);
            }
        }
    }
}
