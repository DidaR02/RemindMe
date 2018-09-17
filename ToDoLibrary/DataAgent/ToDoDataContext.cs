using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToDoLibrary.Models;

namespace ToDoLibrary.DataAgent
{
    public class ToDoDataContext : DbContext
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="options"></param>
        public ToDoDataContext(DbContextOptions<ToDoDataContext> options)
            : base(options)
        {
        }

        public DbSet<ToDo> ToDo { get; set; }
        public DbSet <ToDoType> ToDoType { get; set; }
    }
}
