using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoLibrary.Models;
using System.ComponentModel.DataAnnotations;
using ToDoLibrary.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoLibrary.Models
{
    /// <summary>
    /// Create a ToDo Data Context Model
    /// </summary>
    public class ToDo : ToDoRequestBase
    {
        /// <summary>
        /// ToDoId against which ToDo task should be created. In the DB this will represent a primaryKey
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Range(1, int.MaxValue)]
        public override int ToDoId { get; set; }

        /// <summary>
        /// ToDO title that will display and represent the ToDo Task Name
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        public override string Title { get; set; }

        /// <summary>
        /// Additional information about the ToDo task
        /// </summary>
        public override string Notes { get; set; }

        /// <summary>
        /// Date the ToDo Task was created
        /// </summary>
        [Required]
        public override DateTime DateCreated { get; set; }

        /// <summary>
        /// Optional Reminder date
        /// </summary>
        public override DateTime? ReminderDate { get; set; }

        /// <summary>
        /// Optional Due date
        /// </summary>
        public override DateTime? DueDate { get; set; }

        /// <summary>
        /// Represents a task has been completed
        /// </summary>
        public override bool? IsDone { get; set; }

        /// <summary>
        /// To Do task category.
        /// </summary>
        [Required]
        public override ToDoTypeId? ToDoType { get; set; }
    }
}
