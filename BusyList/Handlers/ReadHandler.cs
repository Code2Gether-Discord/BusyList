using BusyList.Commands;
using System;
using System.Threading.Tasks;
using BusyList.Parsing;
using Sprache;

namespace BusyList.Handlers
{
    internal class ReadHandler : IHandler<ReadCommand>
    {
        private readonly ITaskRepository _taskRepository;

        public ReadHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public void Run(ReadCommand command)
        {
            //TODO: Add logic to make this function run correctly
            var task = _taskRepository.GetTaskById(command.Id);
            Console.WriteLine($"If the ReadHandler was implemented, I would now list details for Task {task}.");
        }
    }
}