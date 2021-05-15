using System.Text;

namespace BusyList
{
    public class TaskItem
    {
        public TaskItem(int id, string description, TaskStatus status = TaskStatus.NotStarted)
        {
            Id = id;
            Description = description;
            TaskStatus = status;
        }
        public int Id { get; }

        public string Description { get; }

        public TaskStatus TaskStatus { get; set; }

        public string Print()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Id {Id}");
            sb.AppendLine($"Description {Description}");
            sb.AppendLine($"Status {TaskStatus}");

            return sb.ToString();
        }
    }
}
