using System;
using ToDoLibrary.Enums;
using Newtonsoft.Json;



namespace ToDoLibrary.Models
{
    public interface IToDoRequest
    {
        /// <summary>
        /// ToDoId against which ToDo task should be created. In the DB this will represent a primaryKey
        /// </summary>        
        int ToDoId { get; set; }

        /// <summary>
        /// ToDO title that will display and represent the ToDo Task Name
        /// </summary>
        string Title { get; set; }

        /// <summary>
        /// Additional information about the ToDo task
        /// </summary>
        string Notes { get; set; }

        /// <summary>
        /// Date the ToDo Task was created
        /// </summary>
        DateTime DateCreated { get; set; }

        /// <summary>
        /// Optional Reminder date
        /// </summary>
        DateTime? ReminderDate { get; set; }

        /// <summary>
        /// Optional Due date
        /// </summary>
        DateTime? DueDate { get; set; }

        /// <summary>
        /// Represents a task has been completed
        /// </summary>
        bool? IsDone { get; set; }

        /// <summary>
        /// To Do task category.
        /// </summary>
        ToDoTypeId? ToDoType { get; set; }

        /// <summary>
        /// Check ToDoType type.
        /// </summary>
        bool Is<T>();
    }
}
