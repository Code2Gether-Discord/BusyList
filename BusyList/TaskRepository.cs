using System;
using System.Collections.Generic;
using System.Linq;

namespace BusyList
{
    public class TaskRepository : ITaskRepository
    {
        private const string PATH = "database.json";

        private readonly IFileService _fileProvider;

        private readonly List<TaskItem> _items = new();
        private int _idCounter = 1;

        public TaskRepository(IFileService fileProvider)
        {
            _fileProvider = fileProvider;

            var storedItems = _fileProvider.DeserializeOrDefault<List<TaskItem>>(PATH);

            if (storedItems != null)
            {
                _items = storedItems;
                _idCounter = _items.Max(task => task.Id) + 1;
            }
        }

        public TaskItem AddTask(AddTaskData data)
        {
            var item = new TaskItem(_idCounter++, data.Description);

            _items.Add(item);

            Save();

            return item;
        }

        public void DeleteTask(TaskItem task)
        {
            Console.WriteLine($"Removed task #{task.Id}");

            _items.Remove(task);

            Save();
        }

        public IEnumerable<TaskItem> GetAll()
        {
            return _items;
        }

        public TaskItem GetTaskById(int id)
        {
            return _items.SingleOrDefault(x => x.Id == id);
        }

        public TaskItem UpdateTask(TaskItem task)
        {
            var oldTask = GetTaskById(task.Id);

            if (oldTask == null)
            {
                throw new Exception("Trying to update non-existing task.");
            }

            _items.Remove(oldTask);
            _items.Add(task);

            Save();

            return task;
        }

        private void Save()
        {
            _fileProvider.SerializeToFile(PATH, _items);
        }
    }
}
