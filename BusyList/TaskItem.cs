using System.Text;

namespace BusyList
{
    public record TaskItem(int Id, string Description, TaskStatus TaskStatus = TaskStatus.NotStarted)
    {
        public string Print()
        {
            var sb = new StringBuilder();

            sb.Append("Id ").Append(Id).AppendLine();
            sb.Append("Description ").AppendLine(Description);
            sb.Append("Status ").Append(TaskStatus).AppendLine();

            return sb.ToString();
        }
    }
}
