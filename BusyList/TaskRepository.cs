using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BusyList
{
    public class TaskRepository : ITaskRepository
    {
        private const string PATH = "database.json";

        private readonly List<TaskItem> _items = new List<TaskItem>();

        private int _idCounter = 1;

        public TaskRepository()
        {
            if (File.Exists(PATH))
            {
                var text = File.ReadAllText(PATH);

                _items = JsonConvert.DeserializeObject<List<TaskItem>>(text);

                _idCounter = _items.Max(task => task.Id) + 1;
            }
        }
        public TaskItem AddTask(AddTaskData data)
        {
            var item = new TaskItem(_idCounter++, data.Description, data.Priority);

            _items.Add(item);

            Save();

            return item;
        }

        public void DeleteTask(TaskItem task)
        {
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

            Save();

            return task;
        }
        private void Save()
        {
            var text = JsonConvert.SerializeObject(_items);

            File.WriteAllText(PATH, text);
        }
    }
}
