using BusyList.Commands;
using System;

namespace BusyList.Handlers
{
    public class DoneHandler : IHandler<DoneCommand>
    {
        private readonly ITaskRepository _taskRepository;

        public DoneHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public void Help()
        {
            Console.WriteLine("Help: Done\n");
            Console.WriteLine("Function: Mark a task as done");
            Console.WriteLine("Syntax: [id] done");
        }

        public void Run(DoneCommand command)
        {
            TaskItem taskItem = _taskRepository.GetTaskById(command.Id);

            taskItem.TaskStatus = TaskStatus.Done;

            _taskRepository.UpdateTask(taskItem);

            Console.WriteLine($"The Task with the id {command.Id} is marked as done now.");
        }
    }
}
