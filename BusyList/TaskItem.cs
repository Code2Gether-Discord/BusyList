using System.Text;

namespace BusyList
{
    public class TaskItem
    {
        public TaskItem(int id, string description, TaskStatus status = TaskStatus.NotStarted)
        {
            Id = id;
            Description = description;
            Status = status;
        }
        public int Id { get; }

        public string Description { get; set; }

        public TaskStatus Status { get; set; }

        public string Print()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Id {Id}");
            sb.AppendLine($"Description {Description}");
            sb.AppendLine($"Status {Status}");

            return sb.ToString();
        }
    }
}
