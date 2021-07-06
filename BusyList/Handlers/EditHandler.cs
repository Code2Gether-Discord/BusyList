﻿using BusyList.Commands;
using System;
using System.Reflection;

namespace BusyList.Handlers
{
    // There are some problems. 
    // Only work for string properties e.g description.
    public class EditHandler : IHandler<EditCommand>
    {
        private readonly ITaskRepository _taskRepository;

        public EditHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public void Run(EditCommand command)
        {
            TaskItem taskItem = _taskRepository.GetTaskById(command.Id);

            if (taskItem != null)
            {
                PropertyInfo propertyInfo = taskItem.GetType().GetProperty(command.Property);

                if(propertyInfo == null)
                {
                    propertyInfo = taskItem.GetType().GetProperty(command.Property.ToUpperInvariant());
                }

                if (propertyInfo != null)
                {
                    propertyInfo.SetValue(taskItem, command.Value);

                    _taskRepository.UpdateTask(taskItem);

                    Console.WriteLine("Task updated");
                }
                else
                {
                    Console.WriteLine($"The property with the name {command.Property} does not exist");
                }
            }
            else 
            {
                Console.WriteLine($"The task with the id {command.Id} does not exist");
            }
        }
    }
}