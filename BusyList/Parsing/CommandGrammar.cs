using BusyList.Commands;
using Sprache;
using System.Linq;

namespace BusyList.Parsing
{
    public static class CommandGrammar
    {
        private static readonly Parser<string> _keywordAdd =
            Parse.IgnoreCase("add").Text();

        private static readonly Parser<string> _keywordEdit =
            Parse.IgnoreCase("edit").Text();

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

        private static readonly Parser<Command> _editCommand =
            from id in _number
            from _ in Parse.WhiteSpace
            from keyword in _keywordEdit
            from __ in Parse.WhiteSpace
            from property in Parse.LetterOrDigit.AtLeastOnce().Text()
            from ___ in Parse.WhiteSpace
            from value in Parse.LetterOrDigit.AtLeastOnce().Text()
            select new EditCommand(id, property, value);

        public static readonly Parser<Command> Source =
            _deleteCommand
            .Or(_nextCommand)
            .Or(_doneCommand)
            .Or(_editCommand)
            .Or(_readCommand)
            .Or(_addCommand)
            .End();
    }
}
