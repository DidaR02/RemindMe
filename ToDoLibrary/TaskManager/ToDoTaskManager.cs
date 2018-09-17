using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using ToDoLibrary.DataAgent;
using ToDoLibrary.Enums;
using ToDoLibrary.Models;

namespace ToDoLibrary.TaskManager
{
    public class ToDoTaskManager : IToDoTaskManager
    {
        public async Task<ToDoListResponse> CreateToDoTask(ToDoDataContext context, ToDo AddToDoRequest)
        {

            ToDo toDo = new ToDo
            {
                //ToDoId = AddToDoRequest.ToDoId,
                Title = AddToDoRequest.Title,
                Notes = AddToDoRequest.Notes,
                DateCreated = DateTime.Now,
                ReminderDate = AddToDoRequest.ReminderDate,
                DueDate = AddToDoRequest.DueDate,
                IsDone = AddToDoRequest.IsDone,
                ToDoType = (ToDoTypeId)AddToDoRequest.ToDoType
            };

            context.ToDo.Add(toDo);
            var response = await context.SaveChangesAsync();

            var getTodo = context.ToDo.SingleOrDefault(getToDo => getToDo.ToDoId == toDo.ToDoId);

            if (getTodo == null)
            {
                throw new Exception("No Data found");
            }
            var toDoListResponse = new ToDoListResponse
            {
                ToDoId = getTodo.ToDoId,
                Title = getTodo.Title,
                DateCreated = getTodo.DateCreated,
                ToDoType = getTodo.ToDoType,
                Notes = getTodo.Notes
            };

            return toDoListResponse;
        }

        public async Task<ToDoListResponse> GetToDoTask(ToDoDataContext context, int ToDoTaskId)
        {
            var getTodo = context.ToDo.SingleOrDefault(getToDo => getToDo.ToDoId == ToDoTaskId);

            if (getTodo == null)
            {
                throw new Exception("No Data found");
            }

            var toDoListResponse = new ToDoListResponse
            {
                ToDoId = getTodo.ToDoId,
                Title = getTodo.Title,
                DateCreated = getTodo.DateCreated,
                ToDoType = getTodo.ToDoType,
                Notes = getTodo.Notes
            };

            return toDoListResponse;

        }


        public async Task<ToDo> EditToDoTask(ToDoDataContext context, int ToDoTaskId, ToDo ToDoRequest)
        {
            if (ToDoTaskId == 0)
            {
                throw new Exception("Invalid TaskId");
            }

            var entity = context.ToDo.Find(ToDoTaskId);
            if (entity != null)
            {

            }

            try
            {

                //await context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                if (ex is DbUpdateConcurrencyException)
                    throw ex;
                else
                    throw ex;
            }

            return ToDoRequest;
        }

    }
}
