namespace BusyList.Commands
{
    public record Command;

    public record ReadCommand(int Id) : Command;
    public record NextCommand() : Command;
    public record AddCommand(string Description) : Command;
    public record DeleteCommand(int Id) : Command;
    public record DoneCommand(int Id) : Command;
    public record EditCommand(int Id, string property, string value) : Command;
}
