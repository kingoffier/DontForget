using DontForgetBackend.API.Contracts;
using DontForgetBackend.Core.Interfaces;
using DontForgetBackend.Core.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DontForgetBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;
        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }


        [Authorize]
        [HttpGet("GetAllTask")]
        public async Task<ActionResult<List<TaskResponse>>> GetTasks()
        {
            var tasks = await _taskService.GetTask();

            var response = tasks.Select(b => new TaskResponse(b.Id, b.NameTask, b.Date, b.Description, b.IdUser));


            return Ok(response);
        }

        [Authorize]
        [HttpGet("GetTaskById/{id:int}")]
        public async Task<ActionResult<List<TaskResponse>>> GetTaskById(int id)
        {
            var tasks = await _taskService.GetTaskById(id);

            var response = tasks.Select(b => new TaskResponse(b.Id, b.NameTask, b.Date, b.Description, b.IdUser));


            return Ok(response);
        }

        [Authorize]
        [HttpPost("CreateNewTask")]
        public async Task<ActionResult<int>> CreateTask([FromBody] TaskRequest taskRequest)
        {
            var (task, error) = TaskModel.Create(
                taskRequest.Id,
                taskRequest.NameTask,
                taskRequest.Date,
                taskRequest.Description,
                taskRequest.IdUser
                );

            if (!string.IsNullOrEmpty(error))
            {
                return BadRequest(error);
            }

            var taskId = await _taskService.CreateTask(task);

            return Ok(taskId);
        }

        [Authorize]
        [HttpPut("UpdateTask/{id:int}")]
        public async Task<ActionResult<int>> UpdateTaskr(int id, [FromBody] TaskRequest2 taskRequest)
        {
            var taskId = await _taskService.UpdateTask(id, taskRequest.NameTask, taskRequest.Date, taskRequest.Description, taskRequest.IdUser);
            return Ok(taskId);
        }

        [Authorize]
        [HttpDelete("DeleteTask/{id:int}")]
        public async Task<ActionResult<int>> DeleteTask(int id)
        {
            return Ok(await _taskService.DeleteTask(id));
        }

        
    }
}
