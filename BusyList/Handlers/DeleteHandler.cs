using BusyList.Commands;
using BusyList.HelpSystem;
using System;

namespace BusyList.Handlers
{
    [HelpAttribute("delete", "Delete the task with the passed id", "[Id] delete")]
    public class DeleteHandler : IHandler<DeleteCommand>
    {
        private readonly ITaskRepository _taskRepository;

        public DeleteHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public void Run(DeleteCommand command)
        {
            var selectedTask = _taskRepository.GetTaskById(command.Id);
            _taskRepository.DeleteTask(selectedTask);
            Console.WriteLine($"Task with id {command.Id} has been deleted.");
        }
    }
}
