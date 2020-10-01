using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorTasks.Shared;

namespace BlazorTasks.Client.Services
{
    public interface ITasksService{
        Task<IEnumerable<TaskModel>> GetTasks(bool onlyCompletedTasks = false);
        Task<TaskModel> AddTask(TaskModel task);
        Task UpdateTask(TaskModel task);
        Task DeleteTask(string taskId);
        Task<TaskModel> GetTask(string taskId);
    }
}