using BusyList.Commands;
using BusyList.Handlers;
using Moq;
using Xunit;

namespace BusyList.Tests.Handlers
{
    public class ReadHandlerTests
    {
        private readonly Mock<ITaskRepository> _mockRepository = new();
        private readonly ReadHandler _handler;

        public ReadHandlerTests()
        {
            _handler = new ReadHandler(_mockRepository.Object);
        }

        [Fact]
        public void Run_ShouldSetTaskStatusToDone_WhenAValidIdIsPassed()
        {
            var command = new ReadCommand(1);

            var task = new TaskItem(command.Id, "Test Description", PriorityEnum.High);

            _mockRepository.Setup(_ => _.GetTaskById(command.Id)).Returns(task);

            _handler.Run(command);

            _mockRepository.Verify(_ => _.GetTaskById(command.Id));
        }
    }
}
