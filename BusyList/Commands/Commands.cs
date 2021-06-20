namespace BusyList.Commands
{
    public record Command;

    public record ReadCommand(int Id) : Command;
    public record NextCommand() : Command;
    public record AddCommand(string Description, PriorityEnum Priority = PriorityEnum.Normal) : Command;
    public record DeleteCommand(int Id) : Command;
    public record DoneCommand(int Id) : Command;
}
