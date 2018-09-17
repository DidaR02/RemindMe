using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ToDoLibrary.Models
{
    public class ToDoType
    {
        /// <summary>
        /// ToDo Type Id
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]        
        [Range(1, int.MaxValue)]
        public int TypeID { get; set; }

        /// <summary>
        /// Type Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Is Active
        /// </summary>
        public int IsActive { get; set; }
    }
}
