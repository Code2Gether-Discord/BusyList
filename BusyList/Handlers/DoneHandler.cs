﻿using BusyList.Commands;
using BusyList.HelpSystem;
using System;

namespace BusyList.Handlers
{
    [HelpAttribute("done", "Mark the task with the given id as done", "[Id] done")]
    public class DoneHandler : IHandler<DoneCommand>
    {
        private readonly ITaskRepository _taskRepository;

        public DoneHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public void Run(DoneCommand command)
        {
            TaskItem taskItem = _taskRepository.GetTaskById(command.Id);

            taskItem.TaskStatus = TaskStatus.Done;

            _taskRepository.UpdateTask(taskItem);

            Console.WriteLine($"The Task with the id {command.Id} is marked as done now.");
        }
    }
}
