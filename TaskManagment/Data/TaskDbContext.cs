using Microsoft.EntityFrameworkCore;
using TaskManagement.Models;

namespace TaskManagement.Data
{
    public class TaskDbContext : DbContext
    {
        /// <summary>
        /// Constructor accepting DbContext options.
        /// </summary>
        public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options) { }

        /// <summary>
        /// DbSet representing the Tasks table.
        /// </summary>
        public DbSet<TaskItem> Tasks { get; set; }
    }
}
