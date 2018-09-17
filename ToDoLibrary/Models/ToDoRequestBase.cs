using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using ToDoLibrary.Enums;
using Newtonsoft.Json;


namespace ToDoLibrary.Models
{
    public abstract class ToDoRequestBase : IToDoRequest

    {
        /// <summary>
        /// Constructor
        /// </summary>
        public ToDoRequestBase()
        {

        }

        /// <summary>
        /// ToDoId against which ToDo task should be created. In the DB this will represent a primaryKey
        /// </summary>
        [Required]
        public virtual int ToDoId { get; set; }

        /// <summary>
        /// ToDO title that will display and represent the ToDo Task Name
        /// </summary>
        [Required]
        public virtual string Title { get; set; }

        /// <summary>
        /// Additional information about the ToDo task
        /// </summary>
        public virtual string Notes { get; set; }

        /// <summary>
        /// Date the ToDo Task was created
        /// </summary>
        [Required]
        public virtual DateTime DateCreated { get; set; }

        /// <summary>
        /// Optional Reminder date
        /// </summary>
        public virtual DateTime? ReminderDate { get; set; }

        /// <summary>
        /// Optional Due date
        /// </summary>
        public virtual DateTime? DueDate { get; set; }

        /// <summary>
        /// Represents a task has been completed
        /// </summary>
        public virtual bool? IsDone { get; set; }

        /// <summary>
        /// To Do task category.
        /// </summary>
        [Required]
        public virtual ToDoTypeId? ToDoType { get; set; }
        
        /// <summary>
        /// Check Controller type.
        /// </summary>
        public bool Is<T>()
        {
            return typeof(T) == GetType();
        }
    }
}
