using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoLibrary.Models;
using ToDoLibrary.DataAgent;

namespace ToDoLibrary.TaskManager
{
    public interface IToDoTaskManager
    {
        /// <summary>
        /// Create new ToDo Task
        /// </summary>
        /// <param name="AddToDoReguest"> ToDo Task Package Request</param>
        /// <returns>Created ToDo Task Response</returns>
        Task<ToDoListResponse> CreateToDoTask(ToDoDataContext context, ToDo AddToDoReguest);

        /// <summary>
        /// Get ToDo Task
        /// </summary>
        /// <param name="ToDoTaskId">ToDo Task ID</param>
        /// <returns>Requested ToDo Task Response</returns>
        Task<ToDoListResponse> GetToDoTask(ToDoDataContext context, int ToDoTaskId);

        /// <summary>
        /// Edit ToDo Task
        /// </summary>
        /// <param name="ToDoTaskId">ToDo Task ID</param>
        /// <param name="ToDoReguest">Requested ToDo Task Package with new or editted data</param>
        /// <returns></returns>
        Task<ToDo> EditToDoTask(ToDoDataContext context, int ToDoTaskId,ToDo ToDoReguest);

    }
}
