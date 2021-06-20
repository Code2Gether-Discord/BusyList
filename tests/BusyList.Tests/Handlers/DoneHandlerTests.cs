using BusyList.Commands;
using BusyList.Handlers;
using FluentAssertions;
using Moq;
using Xunit;

namespace BusyList.Tests.Handlers
{
    public class DoneHandlerTests
    {
        private readonly Mock<ITaskRepository> _taskRepository = new Mock<ITaskRepository>();
        private readonly DoneHandler _subject;

        public DoneHandlerTests()
        {
            _subject = new DoneHandler(_taskRepository.Object);
        }

        [Fact]
        public void Run_ShouldSetTaskStatusToDone_WhenAValidIdIsPassed()
        {
            var command = new DoneCommand(Id: 1);
            var currentTask = new TaskItem(command.Id, "DESC",PriorityEnum.High, TaskStatus.NotStarted);

            _taskRepository.Setup(_ => _.GetTaskById(command.Id)).Returns(currentTask);

            _taskRepository.Setup(_ => _.UpdateTask(It.IsAny<TaskItem>())).Callback<TaskItem>(task =>
                task.TaskStatus.Should().Be(TaskStatus.Done)
            );

            _subject.Run(command);

            _taskRepository.Verify(_ => _.UpdateTask(It.IsAny<TaskItem>()), Times.Once);
        }
    }
}
