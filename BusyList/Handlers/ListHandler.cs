using BusyList.Commands;
using System;
using System.Collections.Generic;

namespace BusyList.Handlers
{
    public class ListHandler : IHandler<DoneCommand>
    {
        private readonly ITaskRepository _taskRepository;

        private const string SEPERATOR = "--------------------------";

        public ListHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public void Run(DoneCommand command)
        {
            var tasks = _taskRepository.GetAll();

            Console.WriteLine("Tasks:");
            Console.WriteLine(SEPERATOR);

            foreach (var item in tasks)
            {
                Console.WriteLine($"Task id: {item.Id}");
                Console.WriteLine($"Description: {item.Description}");
                Console.WriteLine($"Status: {item.TaskStatus}");
                Console.WriteLine(SEPERATOR);
            }
        }
    }
}
