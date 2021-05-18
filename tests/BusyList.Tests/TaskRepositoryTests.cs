using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace BusyList.Tests
{
    public class TaskRepositoryTests
    {
        private readonly Mock<IFileService> _fileService = new Mock<IFileService>();

        [Fact]
        public void AddTask_ShouldCreateTasks()
        {
            var subject = new TaskRepository(_fileService.Object);

            var addTaskData = new AddTaskData("desc");

            var task = subject.AddTask(addTaskData);

            task.Description.Should().Be(addTaskData.Description);
            task.Id.Should().NotBe(default);
        }

        [Fact]
        public void GetById_ShouldReturnNull_WhenNoTaskIdMatched()
        {
            var list = new List<TaskItem>()
            {
                new TaskItem(1, "Test1"),
                new TaskItem(2, "Test2"),
            };

            _fileService.Setup(_ => _.DeserializeOrDefault<List<TaskItem>>(It.IsAny<string>()))
                .Returns(list);

            var subject = new TaskRepository(_fileService.Object);

            var actual = subject.GetTaskById(3);

            actual.Should().BeNull();
        }

        [Fact]
        public void GetById_ShouldReturnATask_WhenATaskIdMatched()
        {
            var list = new List<TaskItem>()
            {
                new TaskItem(1, "Test1"),
                new TaskItem(2, "Test2"),
            };

            _fileService.Setup(_ => _.DeserializeOrDefault<List<TaskItem>>(It.IsAny<string>()))
                .Returns(list);

            var subject = new TaskRepository(_fileService.Object);

            var actual = subject.GetTaskById(1);

            actual.Should().NotBeNull();
            actual.Description.Should().BeEquivalentTo(list[0].Description);
        }

        [Fact]
        public void DeleteTask_ShouldRemoveTask_WhenATaskMatched()
        {
            var list = new List<TaskItem>()
            {
                new TaskItem(1, "Test1"),
                new TaskItem(2, "Test2"),
            };

            _fileService.Setup(_ => _.DeserializeOrDefault<List<TaskItem>>(It.IsAny<string>()))
                .Returns(list);

            var subject = new TaskRepository(_fileService.Object);

            var actual = subject.GetTaskById(1);
            subject.DeleteTask(actual);

            list.Count.Should().Be(1);
            list[0].Id.Should().Be(2);
        }

        [Fact]
        public void DeleteTask_ShouldThrowAnException_WhenNoTaskMatched()
        {
            var list = new List<TaskItem>()
            {
                new TaskItem(1, "Test1"),
                new TaskItem(2, "Test2"),
            };

            _fileService.Setup(_ => _.DeserializeOrDefault<List<TaskItem>>(It.IsAny<string>()))
                .Returns(list);

            var subject = new TaskRepository(_fileService.Object);

            var illegalTask = new TaskItem(1000, "Does not exist");

            subject.Invoking(_ => _.DeleteTask(illegalTask)).Should().Throw<Exception>();
        }

        [Fact]
        public void UpdateTask_ShouldReplaceExistingItem_WhenAnOldItemExisted()
        {
            var list = new List<TaskItem>()
            {
                new TaskItem(1, "Test1"),
                new TaskItem(2, "Test2"),
            };

            _fileService.Setup(_ => _.DeserializeOrDefault<List<TaskItem>>(It.IsAny<string>()))
                .Returns(list);

            var subject = new TaskRepository(_fileService.Object);

            var newTask = list[0] with { Description = "changed" };

            var actual = subject.UpdateTask(newTask);
            var listItemId1 = list.Single(i => i.Id == newTask.Id);

            actual.Should().Be(newTask);
            listItemId1.Should().Be(newTask);
        }

        [Fact]
        public void UpdateTask_ShouldThrowAnException_WhenNoItemExisted()
        {
            var list = new List<TaskItem>()
            {
                new TaskItem(1, "Test1"),
                new TaskItem(2, "Test2"),
            };

            _fileService.Setup(_ => _.DeserializeOrDefault<List<TaskItem>>(It.IsAny<string>()))
                .Returns(list);

            var subject = new TaskRepository(_fileService.Object);

            var newTask = new TaskItem(1000, "Does not exist");

            var actual = subject.Invoking(_ => _.UpdateTask(newTask)).Should().Throw<Exception>();
        }

        [Fact]
        public void GetAll_ShouldReturnAllKnownTasks()
        {
            var list = new List<TaskItem>()
            {
                new TaskItem(1, "Test1"),
                new TaskItem(2, "Test2"),
            };

            _fileService.Setup(_ => _.DeserializeOrDefault<List<TaskItem>>(It.IsAny<string>()))
                .Returns(list);

            var subject = new TaskRepository(_fileService.Object);

            var actual = subject.GetAll();

            actual.Should().BeEquivalentTo(list);
        }
    }
}
