using System.Threading.Tasks;
using BlazorTasks.Client.Services;
using BlazorTasks.Shared;
using Microsoft.AspNetCore.Components;

namespace BlazorTasks.Client.Pages.Tasks
{
    public partial class EditTask
    {
        [Parameter]
        public string TaskId { get; set; }

        private TaskModel task = null;

        [Inject] ITasksService _taskService { get; set; }
        [Inject] NavigationManager _navManager { get; set; }

        protected override async Task OnInitializedAsync()
        {
            task = await _taskService.GetTask(TaskId);
        }

        public async Task UpdateTask()
        {
            await _taskService.UpdateTask(task);
            _navManager.NavigateTo("mytasks");
        }
    }
}