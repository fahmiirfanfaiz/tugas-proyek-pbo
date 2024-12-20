using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskClass.Models;
using Microsoft.EntityFrameworkCore;

namespace TaskClass
{
    public class TaskManager
    {
        private readonly ToDoListDbContext _context;

        public TaskManager(ToDoListDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adds a new task to the database.
        /// </summary>
        public async Task AddTask(string nameTask, string description, DateTime? dueDate, string category)
        {
            var task = new TaskToDo
            {
                NameTask = nameTask,
                Description = description,
                DueDate = dueDate,
                Category = category,
                IsComplete = false
            };
            await _context.TaskToDos.AddAsync(task);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Edits an existing task in the database.
        /// </summary>
        public async Task EditTask(int id, string newNameTask, string newDescription, DateTime newDueDate, string newCategory)
        {
            var task = await FindTaskById(id);
            if (task != null)
            {
                task.NameTask = newNameTask;
                task.Description = newDescription;
                task.DueDate = newDueDate;
                task.Category = newCategory;
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Marks a task as complete.
        /// </summary>
        public async Task MarkTaskAsComplete(int id)
        {
            var task = await FindTaskById(id);
            if (task != null)
            {
                task.IsComplete = true;
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Removes a task from the database.
        /// </summary>
        public async Task RemoveTask(int id)
        {
            var task = await FindTaskById(id);
            if (task != null)
            {
                _context.TaskToDos.Remove(task);
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Gets all tasks from the database.
        /// </summary>
        public async Task<List<TaskToDo>> GetAllTasks()
        {
            return await _context.TaskToDos.ToListAsync();
        }

        /// <summary>
        /// Finds a task by its ID.
        /// </summary>
        private async Task<TaskToDo> FindTaskById(int id)
        {
            return await _context.TaskToDos.FindAsync(id);
        }
    }
}
