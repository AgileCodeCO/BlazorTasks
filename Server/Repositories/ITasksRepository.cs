using System;
using System.Collections.Generic;
using BlazorTasks.Shared;

namespace BlazorTasks.Server.Repositories
{
    public interface ITasksRepository{
        IEnumerable<Task> GetTasks();
        Task AddTask(Task task);
        void UpdateTask(Task task);
        void DeleteTask(string taskId);
        Shared.Task GetTask(string taskId);
    }
}