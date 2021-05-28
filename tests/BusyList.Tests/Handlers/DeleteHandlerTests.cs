using BusyList.Commands;
using BusyList.Handlers;
using FluentAssertions;
using Moq;
using Xunit;

namespace BusyList.Tests.Handlers
{
    public class DeleteHandlerTests
    {
        private readonly Mock<ITaskRepository> _taskRepository = new Mock<ITaskRepository>();
        private readonly DeleteHandler _subject;

        public DeleteHandlerTests()
        {
            _subject = new DeleteHandler(_taskRepository.Object);
        }

        [Fact]
        public void Run_ShouldCallDeleteTask_WhenAValidIdIsPassed()
        {
            var command = new DeleteCommand(Id: 1);
            var currentTask = new TaskItem(command.Id, "DESC", PriorityEnum.High , TaskStatus.NotStarted);

            _taskRepository.Setup(_ => _.GetTaskById(command.Id)).Returns(currentTask);

            _taskRepository.Setup(_ => _.DeleteTask(It.IsAny<TaskItem>())).Callback<TaskItem>(task =>
                task.Should().Be(currentTask)
            );

            _subject.Run(command);

            _taskRepository.Verify(_ => _.DeleteTask(It.IsAny<TaskItem>()), Times.Once);
        }
    }
}
