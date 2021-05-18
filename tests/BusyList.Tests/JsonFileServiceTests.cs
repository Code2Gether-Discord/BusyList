using FluentAssertions;
using System.IO;
using Xunit;

namespace BusyList.Tests
{
    public class JsonFileServiceTests
    {
        private readonly JsonFileService _subject;

        public JsonFileServiceTests()
        {
            _subject = new JsonFileService();
        }

        [Fact]
        public void DeserializeOrDefault_ShouldReturnAValidObject_WhenAJsonFileWasProvided()
        {
            const string filename = "deserialize_valid.test";
            const string content = @"{""Number"":1,""Text"":""a""}";
            File.WriteAllText(filename, content);

            var actual = _subject.DeserializeOrDefault<TestClass>(filename);

            actual.Number.Should().Be(1);
            actual.Text.Should().Be("a");

            File.Delete(filename);
        }

        [Fact]
        public void SerializeToFile_ShouldWriteJsonToFile()
        {
            const string filename = "serialize_valid.test";
            const string content = @"{""Number"":1,""Text"":""a""}";
            var obj = new TestClass { Number = 1, Text = "a" };

            _subject.SerializeToFile(filename, obj);

            File.Exists(filename).Should().BeTrue();
            File.ReadAllText(filename).Should().Be(content);

            File.Delete(filename);
        }

        [Fact]
        public void DeserializeOrDefault_ShouldReturnDefault_WhenNoFileExists()
        {
            var actual = _subject.DeserializeOrDefault<TestClass>("DOESNOTEXIST");

            actual.Should().Be(default);
        }
    }
    internal class TestClass
    {
        public int Number { get; set; }
        public string Text { get; set; }
    }
}
