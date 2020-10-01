using System;
using System.Collections.Generic;
using BlazorTasks.Shared;

namespace BlazorTasks.Server.Repositories
{
    public interface ITasksRepository{
        IEnumerable<TaskModel> GetTasks();
        TaskModel AddTask(TaskModel task);
        void UpdateTask(TaskModel task);
        void DeleteTask(string taskId);
        TaskModel GetTask(string taskId);
    }
}