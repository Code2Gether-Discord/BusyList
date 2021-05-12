using BusyList.Commands;
using BusyList.Handlers;
using Moq;
using System.Collections.Generic;
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

        // Should improve the test later
        // For now we only the test that the method dont throw exceptions
        [Fact]
        public void Run_ShouldDontThrowExceptions()
        {
            var command = new NextCommand();

            _nextHandler.Run(command);

            _taskRepository.Verify(_ => _.GetAll(), Times.Once);
        }
    }
}
