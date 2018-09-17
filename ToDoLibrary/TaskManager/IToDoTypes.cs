using System.Threading.Tasks;
using ToDoLibrary.DataAgent;
using ToDoLibrary.Models;

namespace ToDoLibrary.TaskManager
{
    public interface IToDoTypes
    {
        /// <summary>
        /// Create new ToDoType
        /// </summary>
        /// <param name="AddTypeReguest"> ToDoType Package Request</param>
        /// <returns>Created TypeResponse Response</returns>
        Task<ToDoTypeResponse> CreateToDoType(ToDoDataContext context, ToDoType AddTypeReguest);

        /// <summary>
        /// Get ToDoType
        /// </summary>
        /// <param name="TypeId">ToDo Task ID</param>
        /// <returns>Requested TypeResponse Response</returns>
        Task<ToDoTypeResponse> GetToDoType(ToDoDataContext context, int TypeId);

        /// <summary>
        /// Edit ToDoType Task
        /// </summary>
        /// <param name="ToDoTypeID">ToDoTypeID</param>
        /// <param name="TypeReguest">Requested ToDoType Package with new or editted data</param>
        /// <returns>TypeResponse</returns>
        Task<ToDoTypeResponse> EditToDoType(ToDoDataContext context, int ToDoTypeID, ToDoType TypeReguest);

    }
}
