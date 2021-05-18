using BusyList.Commands;
using BusyList.Handlers;
using Moq;
using Xunit;

namespace BusyList.Tests.Handlers
{
    public class NextHandlerTests
    {
        private readonly Mock<ITaskRepository> _taskRepository = new Mock<ITaskRepository>();
        private readonly NextHandler _nextHandler;

        public NextHandlerTests()
        {
            _nextHandler = new NextHandler(_taskRepository.Object);
        }

        [Fact]
        public void Run_ShouldNotThrowExceptions()
        {
            var command = new NextCommand();

            var tasks = new[] {
                new TaskItem(1, "desc")
            };

            _taskRepository.Setup(_ => _.GetAll()).Returns(tasks);

            _nextHandler.Run(command);

            _taskRepository.Verify(_ => _.GetAll(), Times.Once);
        }
    }
}
