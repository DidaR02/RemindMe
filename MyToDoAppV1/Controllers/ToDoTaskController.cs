using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using ToDoLibrary.DataAgent;
using ToDoLibrary.Models;
using ToDoLibrary.TaskManager;

namespace MyToDoAppV1.Controllers
{
    /// <summary>
    /// ToDoTask Container
    /// </summary>
    [Produces("application/json")]
    //[Route("ToDoTask")]
    public class ToDoTaskController : Controller
    {        
        private readonly ToDoDataContext _context;
        public ToDoTaskController(ToDoDataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Add ToDo Task
        /// </summary>
        /// <param name="ToDoTaskRequest">ToDo Task request data</param>
        /// <returns>ToDO Task response</returns>
        [ProducesResponseType(typeof(ToDo), 200)]
        [ProducesResponseType(404)]
        [HttpPost("AddTask")]
        public async Task<IActionResult> AddToDoTaskAsync([FromBody]ToDo ToDoTaskRequest)
        {
            if(ToDoTaskRequest == null)
            {
                throw new Exception("This is invalid"); 
            }

            ToDoTaskManager toDoTaskManager = new ToDoTaskManager();
            var dataResponse =  await toDoTaskManager.CreateToDoTask(_context, ToDoTaskRequest);

            //var response = new ToDoListResponse();
            return Ok(dataResponse);
        }

        /// <summary>
        /// Get ToDo Task
        /// </summary>
        /// <param name="ToDoId">ToDoId</param>
        /// <returns>ToDO Task response</returns>
        [ProducesResponseType(typeof(ToDo), 200)]
        [ProducesResponseType(404)]
        [HttpGet("GetToDoTask/{ToDoId:int}")]
        public async Task<IActionResult> GetToDoTaskAsync([FromRoute]int ToDoId)
        {

            ToDoTaskManager toDoTaskManager = new ToDoTaskManager();
            var dataResponse = await toDoTaskManager.GetToDoTask(_context, ToDoId);

            return Ok(dataResponse);
        }

        /// <summary>
        /// Update ToDo Task
        /// </summary>
        /// <param name="ToDoId"></param>
        /// <param name="ToDoTaskRequest">Updated ToDo Task request data</param>
        /// <returns>ToDO Task response</returns>
        [ProducesResponseType(typeof(ToDo), 200)]
        [ProducesResponseType(404)]
        [HttpPut("UpdateTask/{ToDoId:int}")]
        public async Task<IActionResult> UpdateTaskAsync( int ToDoId, [FromBody]ToDo ToDoTaskRequest)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            //If the id doesnt exist in the db
            //return NotFound();

            if (ToDoTaskRequest == null)
            {
                throw new Exception("This is invalid");
            }

            ToDoTaskManager toDoTaskManager = new ToDoTaskManager();
            var dataResponse = await toDoTaskManager.EditToDoTask(_context, ToDoId, ToDoTaskRequest);

            return Ok(dataResponse);
        }
    }
}