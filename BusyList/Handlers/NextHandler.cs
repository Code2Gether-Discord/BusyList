using BusyList.Commands;
using BusyList.HelpSystem;
using System;

namespace BusyList.Handlers
{

    [HelpAttribute("next", "Lists all tasks", "next")] 
    public class NextHandler : IHandler<NextCommand>
    {
        private readonly ITaskRepository _taskRepository;

        private const string SEPERATOR = "--------------------------";

        public NextHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public void Run(NextCommand command)
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
