using BusyList.Commands;
using System;

namespace BusyList.Handlers
{
    public class DoneHandler : IHandler<DoneCommand>
    {
        private readonly ITaskRepository _TaskRepository;

        public DoneHandler(ITaskRepository taskRepository)
        {
            _TaskRepository = taskRepository;
        }

        public void Run(DoneCommand command)
        {
            TaskItem oldTaskItem = _TaskRepository.GetTaskById(command.Id);

            TaskItem updatedTaskItem = oldTaskItem with { TaskStatus = TaskStatus.Done };

            _TaskRepository.UpdateTask(updatedTaskItem);

            Console.WriteLine($"The Task with the id {command.Id} is marked as done now.");
        }
    }
}
