using BusyList.Commands;
using BusyList.Handlers;
using Moq;
using Xunit;

namespace BusyList.Tests.Handlers
{
    public class AddHandlerTests
    {
        private readonly Mock<ITaskRepository> _taskRepository = new Mock<ITaskRepository>();
        private readonly AddHandler _subject;

        public AddHandlerTests()
        {
            _subject = new AddHandler(_taskRepository.Object);
        }

        [Fact]
        public void Run_ShouldAddATaskToTheRepository()
        {
            var command = new AddCommand("desc");

            var taskItem = new TaskItem(1, command.Description);
            _taskRepository.Setup(_ => _.AddTask(It.IsAny<AddTaskData>())).Returns(taskItem);

            _subject.Run(command);

            _taskRepository.Verify(_ => _.AddTask(It.IsAny<AddTaskData>()), Times.Once);
        }
    }
}
