using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BlazorTasks.Shared;

namespace BlazorTasks.Client.Services
{
    public class TasksService : ITasksService
    {
        private HttpClient httpClient;

        public TasksService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<TaskModel> AddTask(TaskModel task)
        {
            var httpResponse = await httpClient.PostAsJsonAsync<TaskModel>("tasks", task);

            return await httpResponse.Content.ReadFromJsonAsync<TaskModel>();
        }

        public async Task DeleteTask(string taskId)
        {
            await httpClient.DeleteAsync($"tasks/{taskId}");
        }

        public async Task<TaskModel> GetTask(string taskId)
        {
             return await httpClient.GetFromJsonAsync<TaskModel>($"tasks/{taskId}");
        }

        public async Task<IEnumerable<TaskModel>> GetTasks(bool onlyCompletedTasks = false)
        {
            var tasks = await httpClient.GetFromJsonAsync<TaskModel[]>("tasks");
            return tasks.Where(t=>t.IsCompleted == onlyCompletedTasks);
        }

        public async Task UpdateTask(TaskModel task)
        {
            await httpClient.PutAsJsonAsync<TaskModel>("tasks", task);
        }
    }
}