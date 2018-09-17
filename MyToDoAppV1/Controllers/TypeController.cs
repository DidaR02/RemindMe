using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using ToDoLibrary.DataAgent;
using ToDoLibrary.Models;
using ToDoLibrary.TaskManager;

namespace MyToDoAppV1.Controllers
{
    /// <summary>
    /// TypeController
    /// </summary>
    [Produces("application/json")]
    //[Route("api/Type")]
    public class TypeController : Controller
    {
        private readonly ToDoDataContext _context;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public TypeController(ToDoDataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Add ToDo Task
        /// </summary>
        /// <param name="TypeRequest">ToDo Task request data</param>
        /// <returns>ToDO Task response</returns>
        [ProducesResponseType(typeof(ToDoType), 200)]
        [ProducesResponseType(404)]
        [HttpPost("AddType")]
        public async Task<IActionResult> AddTypeAsync([FromBody]ToDoType TypeRequest)
        {
            if (TypeRequest == null || TypeRequest.Description == null)
            {
                throw new Exception("This is invalid");
            }

            ToDoTypes ToDoType = new ToDoTypes();
            var dataResponse = await ToDoType.CreateToDoType(_context, TypeRequest);

            return Ok(dataResponse);
        }

        /// <summary>
        /// GetToDoType
        /// </summary>
        /// <param name="TypeId"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(ToDoType), 200)]
        [ProducesResponseType(404)]
        [HttpGet("GetToDoType/{TypeId:int}")]
        public async Task<IActionResult> GetToDoTypeAsync([FromRoute]int TypeId)
        {

            ToDoTypes ToDoType = new ToDoTypes();
            var dataResponse = await ToDoType.GetToDoType(_context, TypeId);

            return Ok(dataResponse);
        }

        /// <summary>
        /// EditToDoType
        /// </summary>
        /// <param name="TypeId"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(ToDoType), 200)]
        [ProducesResponseType(404)]
        [HttpGet("EditToDoType/{TypeId:int}")]
        public async Task<IActionResult> EditToDoTypeAsync([FromRoute]int TypeId, [FromBody]ToDoType TypeRequest)
        {
            if (TypeRequest == null || TypeRequest.Description == null)
            {
                throw new Exception("This is invalid");
            }

            ToDoTypes ToDoType = new ToDoTypes();
            var dataResponse = await ToDoType.EditToDoType(_context, TypeId, TypeRequest);

            return Ok(dataResponse);
        }

    }
}