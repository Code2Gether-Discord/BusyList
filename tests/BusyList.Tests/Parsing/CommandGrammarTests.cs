using BusyList.Commands;
using BusyList.Parsing;
using FluentAssertions;
using Sprache;
using Xunit;

namespace BusyList.Tests.Parsing
{
    public class CommandGrammarTests
    {
        [Theory]
        [InlineData("add", "withoutspaces")]
        [InlineData("add", "with spaces")]
        public void Source_ShouldParse_AddCommand(params string[] input)
        {
            var text = string.Join(" ", input);
            var actual = CommandGrammar.Source.Parse(text);

            actual.Should().BeOfType<AddCommand>();
            var command = actual as AddCommand;
            command.Description.Should().Be(input[1]);
        }

        [Theory]
        [InlineData("5", "done")]
        public void Source_ShouldParse_DoneCommand(params string[] input)
        {
            var text = string.Join(" ", input);
            var actual = CommandGrammar.Source.Parse(text);

            actual.Should().BeOfType<DoneCommand>();
            var command = actual as DoneCommand;
            command.Id.ToString().Should().Be(input[0]);
        }

        [Theory]
        [InlineData("5", "delete")]
        [InlineData("5", "del")]
        public void Source_ShouldParse_DeleteCommand(params string[] input)
        {
            var text = string.Join(" ", input);
            var actual = CommandGrammar.Source.Parse(text);

            actual.Should().BeOfType<DeleteCommand>();
            var command = actual as DeleteCommand;
            command.Id.ToString().Should().Be(input[0]);
        }
    }
}
