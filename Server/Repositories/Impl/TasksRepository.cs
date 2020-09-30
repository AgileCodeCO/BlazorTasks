using System;
using System.Collections.Generic;
using BlazorTasks.Shared;
using System.Linq;

namespace BlazorTasks.Server.Repositories
{
    public class TasksRepository : ITasksRepository
    {
        private List<Task> _currentTasks = new List<Task>();
        public Task AddTask(Task task)
        {
            string taskId = Guid.NewGuid().ToString().ToUpper();
            task.TaskId = taskId;
            task.IsCompleted = false;

            _currentTasks.Add(task);

            return task;
        }

        public void DeleteTask(string taskId)
        {
            _currentTasks.RemoveAll(t => t.TaskId == taskId);
        }

        public Task GetTask(string taskId)
        {
            return _currentTasks.FirstOrDefault(t => t.TaskId == taskId);
        }

        public IEnumerable<Task> GetTasks()
        {
            return _currentTasks;
        }

        public void UpdateTask(Task task)
        {
            var taskToUpdate = _currentTasks.FirstOrDefault(t => t.TaskId == task.TaskId);
            if (taskToUpdate == null)
                return;

            taskToUpdate.Title = task.Title;
            taskToUpdate.Description = task.Description;
            taskToUpdate.DueDate = task.DueDate;
            taskToUpdate.IsCompleted = task.IsCompleted;
        }
    }
}