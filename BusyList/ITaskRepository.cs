using System.Collections.Generic;

namespace BusyList
{
    public enum TaskStatus
    {
        NotStarted,
        InProgress,
        Done
    }

    public record AddTaskData(string Description, PriorityEnum Priority);


    public interface ITaskRepository
    {
        /// <summary>
        /// Get a task from the repository that matches the id parameter. 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The first task that matches the id parameter.</returns>
        TaskItem GetTaskById(int id);

        /// <summary>
        /// Add a new task to the repository.
        /// </summary>
        /// <param name="data">Input data for the new task.</param>
        /// <returns>The newly created task in the repository.</returns>
        TaskItem AddTask(AddTaskData data);

        /// <summary>
        /// Marks the task as deleted in the repository.
        /// </summary>
        /// <param name="task"></param>
        /// <returns>The updated task.</returns>
        void DeleteTask(TaskItem task);

        /// <summary>
        /// Gets all the tasks in the repository.
        /// </summary>
        /// <returns>All tasks in the repository.</returns>
        IEnumerable<TaskItem> GetAll();

        /// <summary>
        /// Update an existing task in the repository.
        /// </summary>
        /// <param name="task"></param>
        /// <returns>The updated task.</returns>
        TaskItem UpdateTask(TaskItem task);
    }
}
