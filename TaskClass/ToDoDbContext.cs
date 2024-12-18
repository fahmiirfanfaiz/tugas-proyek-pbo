using Microsoft.EntityFrameworkCore;

namespace TaskClass
{
    public class ToDoDbContext : DbContext
    {
        public DbSet<TaskToDo> Tasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=ToDoList.db");
        }
    }
}
