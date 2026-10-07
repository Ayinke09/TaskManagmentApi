using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagmentApi.DTO;
using TaskManagmentApi.Model;
using TaskManagmentApi.Services.Interface;


namespace TaskManagmentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskItemController : ControllerBase
    {
        private readonly ITaskItemServices _serv;
        public TaskItemController(ITaskItemServices serv)
        {
            _serv = serv;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTaskItemAsync()

        {
            var TaskItem = await _serv.GetAllTaskItemAsync();
            return Ok(TaskItem);
        }

        [HttpGet("Get-By-Id")]
        public async Task<IActionResult> GetTaskItemByIdAsync(int id)
        {
            var TaskItem = await _serv.GetTaskITemByIdAsync(id);
            return Ok(TaskItem);
        }
        [HttpPost]
        public async Task<IActionResult> CreateTaskItemAsync(CreateTaskItemDto TaskItem)
        { 
            var newTaskItem = await _serv.CreateTaskItemAsync(TaskItem);
            return Ok(newTaskItem);
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateTaskItemAsync([FromQuery] int id, [FromBody] UpdateTaskItemDto TaskItem)
        {
            var newTaskItem = await _serv.UpdateTaskItemAsync(id, TaskItem);
            return Ok(newTaskItem);
        }

        [HttpDelete]

        public async Task<IActionResult> DeleteTaskItemAsync(int id)
        {
            await _serv.DeleteTaskItemAsync(id);
            return NoContent();
        }
    }

    }
    


