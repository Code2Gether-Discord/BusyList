using BusyList.Commands;
using Sprache;

namespace BusyList.Parsing
{
    public static class CommandGrammar
    {
        private static readonly Parser<string> _keywordAdd =
            Parse.IgnoreCase("add").Text();

        private static readonly Parser<string> _keywordDelete =
            Parse.IgnoreCase("delete")
            .Or(Parse.IgnoreCase("del"))
            .Text();

        private static readonly Parser<string> _keywordDone =
            Parse.IgnoreCase("done").Text();

        private static readonly Parser<string> _keywordNext =
            Parse.IgnoreCase("next").Text();

        private static readonly Parser<int> _number =
            Parse.Number.Select(s => int.Parse(s));
        
        private static readonly Parser<PriorityEnum> _lowPriority =
            Parse.IgnoreCase("Low")
            .Or(Parse.IgnoreCase("L"))
            .Return(PriorityEnum.Low);  
        
        private static readonly Parser<PriorityEnum> _normalPriority =
            Parse.IgnoreCase("Normal")
            .Or(Parse.IgnoreCase("N"))
            .Return(PriorityEnum.Normal);
        
        private static readonly Parser<PriorityEnum> _highPriority =
            Parse.IgnoreCase("High")
            .Or(Parse.IgnoreCase("H"))
            .Return(PriorityEnum.High);

        private static readonly Parser<PriorityEnum> _priority =
            _lowPriority
            .Or(_normalPriority)
            .Or(_highPriority);

        private static readonly Parser<Command> _readCommand =
            from id in _number
            select new ReadCommand(id);

        private static readonly Parser<Command> _nextCommand =
            from keyword in _keywordNext
            select new NextCommand();

        private static readonly Parser<Command> _addCommand =
            from keyword in _keywordAdd
            from _ in Parse.WhiteSpace
            from description in Parse.AnyChar.AtLeastOnce().Text()
            select new AddCommand(description);
        
        private static readonly Parser<Command> _addCommandWithPriority =
            from keyword in _keywordAdd
            from _ in Parse.WhiteSpace
            from pFlag in Parse.Char('p').Once()
            from colon in Parse.Char(':').Once()
            from priority in _priority
            from __ in Parse.WhiteSpace 
            from description in Parse.AnyChar.AtLeastOnce().Text()
            select new AddCommand(description, priority);

        private static readonly Parser<Command> _deleteCommand =
            from id in _number
            from _ in Parse.WhiteSpace
            from keyword in _keywordDelete
            select new DeleteCommand(id);

        private static readonly Parser<Command> _doneCommand =
            from id in _number
            from _ in Parse.WhiteSpace
            from keyword in _keywordDone
            select new DoneCommand(id);

        public static readonly Parser<Command> Source =
            _deleteCommand
            .Or(_nextCommand)
            .Or(_doneCommand)
            .Or(_readCommand)
            .Or(_addCommandWithPriority)
            .Or(_addCommand)
            .End();
    }
}
