using Shared = BlazorTasks.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BlazorTasks.Server.Repositories;

namespace BlazorTasks.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ILogger<TasksController> logger;
        private ITasksRepository _tasksRepository;

        public TasksController(ILogger<TasksController> logger, ITasksRepository tasksRepository)
        {
            this.logger = logger;
            _tasksRepository = tasksRepository;
        }

        [HttpGet]
        public IEnumerable<Shared.Task> Get()
        {
            return _tasksRepository.GetTasks();
        }

        [HttpGet]
        [Route("{taskId}")]
        public IActionResult Get([FromRoute] string taskId)
        {
            var task = _tasksRepository.GetTask(taskId);
            if (task == null)
                return NotFound();

            return Ok(task);
        }

        [HttpPost]
        public Shared.Task Add([FromBody] Shared.Task task)
        {
            return _tasksRepository.AddTask(task);
        }

        [HttpPut]
        public void Update([FromBody] Shared.Task task)
        {
            _tasksRepository.UpdateTask(task);
        }

        [HttpDelete]
        [Route("{taskId}")]
        public void Delete([FromRoute] string taskId)
        {
            _tasksRepository.DeleteTask(taskId);
        }
    }
}
