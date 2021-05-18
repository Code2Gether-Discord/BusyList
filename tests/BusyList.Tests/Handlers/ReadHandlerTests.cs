using BusyList.Commands;
using BusyList.Handlers;
using Moq;
using Xunit;

namespace BusyList.Tests.Handlers
{
    public class ReadHandlerTests
    {
        private readonly Mock<ITaskRepository> _taskRepository = new Mock<ITaskRepository>();
        private readonly ReadHandler _readHandler;

        public ReadHandlerTests()
        {
            _readHandler = new ReadHandler(_taskRepository.Object);
        }

        [Fact]
        public void Run_ShouldNotThrowExceptions_WhenATaskExists()
        {
            var command = new ReadCommand(1);

            var task = new TaskItem(1, "desc");

            _taskRepository.Setup(_ => _.GetTaskById(command.Id)).Returns(task);

            _readHandler.Run(command);

            _taskRepository.Verify(_ => _.GetTaskById(command.Id), Times.Once);
        }

        [Fact]
        public void Run_ShouldNotThrowExceptions_WhenATaskDoesNotExists()
        {
            var command = new ReadCommand(1);

            _taskRepository.Setup(_ => _.GetTaskById(command.Id)).Returns<TaskItem>(default);

            _readHandler.Run(command);

            _taskRepository.Verify(_ => _.GetTaskById(command.Id), Times.Once);
        }
    }
}
