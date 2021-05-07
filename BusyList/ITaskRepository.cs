using System.Collections.Generic;

namespace BusyList
{
    public record AddTaskData(string Description);

    public record TaskItem(int Id, string Description);

    public interface ITaskRepository
    {
        /// <summary>
        /// Get a task from the repository that matches the id parameter. 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Taks from the repository.</returns>
        TaskItem GetTaskById(int id);

        /// <summary>
        /// It add a new task to the repository.
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Input from user to make a new task that get to the repository.</returns>
        TaskItem AddTask(AddTaskData data);

        /// <summary>
        /// It delete the task out of the repository.
        /// </summary>
        /// <param name="task"></param>
        /// <returns>Message that it is delete out of the repository.</returns>
        TaskItem DeleteTask(TaskItem task);

        /// <summary>
        /// Gets all the tasks in the repository.
        /// </summary>
        /// <returns>All tasks in the repository.</returns>
        IEnumerable<TaskItem> GetAll();

        /// <summary>
        /// It update an existing task what is in the repository.
        /// </summary>
        /// <param name="task"></param>
        /// <returns>It shows the update its version from the repository.</returns>
        TaskItem UpdateTask(TaskItem task);
    }
}
