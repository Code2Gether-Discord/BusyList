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

        public void Run(DoneCommand command)
        {
            TaskItem taskItem = _taskRepository.GetTaskById(command.Id);

            if(taskItem == null)
            {
                Console.WriteLine($"The task with the id {command.Id} does not exist");
                return;
            }

            taskItem.TaskStatus = TaskStatus.Done;

            _taskRepository.UpdateTask(taskItem);

            Console.WriteLine($"The Task with the id {command.Id} is marked as done now.");
        }
    }
}
