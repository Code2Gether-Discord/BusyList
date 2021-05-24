using BusyList.Commands;
using System.Reflection;

namespace BusyList.Handlers
{
    public class EditHandler : IHandler<EditCommand>
    {
        private readonly ITaskRepository _taskRepository;

        public EditHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public void Run(EditCommand command)
        {
            TaskItem taskItem = _taskRepository.GetTaskById(command.Id);

            PropertyInfo propertyInfo = taskItem.GetType().GetProperty(command.property);

            propertyInfo.SetValue(taskItem, command.value);

            _taskRepository.UpdateTask(taskItem);
        }
    }
}
