using System;
using System.Linq;
using System.Threading.Tasks;
using ToDoLibrary.DataAgent;
using ToDoLibrary.Models;

namespace ToDoLibrary.TaskManager
{
    public class ToDoTypes : IToDoTypes
    {

        /// <summary>
        /// Add Type
        /// </summary>
        /// <param name="context"></param>
        /// <param name="AddTypeReguest"></param>
        /// <returns></returns>
        public async Task<ToDoTypeResponse> CreateToDoType(ToDoDataContext context, ToDoType AddTypeReguest)
        {
            ToDoType type = new ToDoType
            {
                Description = AddTypeReguest.Description
            };

            context.ToDoType.Attach(entity: type);
            context.ToDoType.Add(type);
            var response = await context.SaveChangesAsync();

            if (response != 1)
                throw new Exception("Failed to save Types");

            var getSavedType = context.ToDoType.FirstOrDefault(t => t.Description == type.Description);

            ToDoTypeResponse typeResponse = new ToDoTypeResponse
            {
                TypeID = getSavedType.TypeID,
                Description = getSavedType.Description,
                IsActive = getSavedType.IsActive
            };
            return typeResponse;

        }

        /// <summary>
        /// Get Type
        /// </summary>
        /// <param name="context"></param>
        /// <param name="TypeId"></param>
        /// <returns></returns>
        public async Task<ToDoTypeResponse> GetToDoType(ToDoDataContext context, int TypeId)
        {
            var getType = context.ToDoType.FirstOrDefault(t => t.TypeID == TypeId);

            if (getType == null)
            {
                throw new Exception("No Data found");
            }
            
            ToDoTypeResponse typeResponse = new ToDoTypeResponse
            {
                TypeID = getType.TypeID,
                Description = getType.Description,
                IsActive = getType.IsActive
            };
            return typeResponse;
        }

        /// <summary>
        /// Edit Type
        /// </summary>
        /// <param name="context"></param>
        /// <param name="ToDoTypeID"></param>
        /// <param name="TypeReguest"></param>
        /// <returns></returns>
        public async Task<ToDoTypeResponse> EditToDoType(ToDoDataContext context, int ToDoTypeID, ToDoType TypeReguest)
        {

            if (ToDoTypeID == 0)
            {
                throw new Exception("Invalid TaskId");
            }


            ToDoType type = new ToDoType
            {
                TypeID = ToDoTypeID,
                Description = TypeReguest.Description,
                IsActive = TypeReguest.IsActive
            };

            var entity = context.ToDo.Find(type);
            if (entity != null)
            {

            }
            return new ToDoTypeResponse();
        }
    }
}
