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
            TaskItem oldTaskItem = _taskRepository.GetTaskById(command.Id);

            TaskItem updatedTaskItem = oldTaskItem with { TaskStatus = TaskStatus.Done };

            _taskRepository.UpdateTask(updatedTaskItem);

            Console.WriteLine($"The Task with the id {command.Id} is marked as done now.");
        }
    }
}
