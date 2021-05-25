using BusyList.Commands;
using Sprache;
using System.Linq;

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

        private static readonly Parser<string> _priority =
            Parse.IgnoreCase("Low")
            .Or(Parse.IgnoreCase("Medium"))
            .Or(Parse.IgnoreCase("High"))
            .Or(Parse.IgnoreCase("L"))
            .Or(Parse.IgnoreCase("M"))
            .Or(Parse.IgnoreCase("H"))
            .Text();
        
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
            select new AddCommand(description, "");
        
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
