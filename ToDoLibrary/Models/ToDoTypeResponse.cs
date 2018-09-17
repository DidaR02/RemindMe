using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ToDoLibrary.Models
{
    public class ToDoTypeResponse
    {
        /// <summary>
        /// ToDo Type Id
        /// </summary>      
        public int TypeID { get; set; }

        /// <summary>
        /// Type Description
        /// </summary>
        public string Description { get; set; }

        public int IsActive { get; set; }
    }
}
