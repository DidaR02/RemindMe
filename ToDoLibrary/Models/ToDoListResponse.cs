using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoLibrary.Enums;
using System.ComponentModel.DataAnnotations;

namespace ToDoLibrary.Models
{
    /// <summary>
    /// Create a ToDo List Response
    /// </summary>
    public class ToDoListResponse
    {
        /// <summary>
        /// ToDoId against which ToDo task should be created. In the DB this will represent a primaryKey
        /// </summary>
        [Required]
        public int ToDoId { get; set; }

        /// <summary>
        /// ToDO title that will display and represent the ToDo Task Name
        /// </summary>
        [Required]
        public string Title { get; set; }

        /// <summary>
        /// Additional information about the ToDo task
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// Date the ToDo Task was created
        /// </summary>
        [Required]
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Optional Reminder date
        /// </summary>
        public DateTime? ReminderDate { get; set; }

        /// <summary>
        /// Optional Due date
        /// </summary>
        public DateTime? DueDate { get; set; }

        /// <summary>
        /// Represents a task has been completed
        /// </summary>
        public bool? IsDone { get; set; }

        /// <summary>
        /// To Do task category.
        /// </summary>
        [Required]
        public ToDoTypeId? ToDoType { get; set; }
    }
}
