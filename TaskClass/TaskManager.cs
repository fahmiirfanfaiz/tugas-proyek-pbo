using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskClass.Models;

namespace TaskClass
{
    public class TaskManager
    {
        private readonly ToDoListDbContext _context;

        public TaskManager(ToDoListDbContext context)
        {
            _context = context;
        }

        public void AddTask(string nameTask, string description, DateTime? dueDate, string category)
        {
            var task = new TaskToDo
            {
                NameTask = nameTask,
                Description = description,
                DueDate = dueDate,
                Category = category,
                IsComplete = false
            };
            _context.TaskToDos.Add(task);
            _context.SaveChanges();
        }

        public void EditTask(int id, string newNameTask, string newDescription, DateTime newDueDate, string newCategory)
        {
            var task = _context.TaskToDos.Find(id); // Use _context.TaskToDos to find the task by ID
            if (task != null)
            {
                task.NameTask = newNameTask;
                task.Description = newDescription;
                task.DueDate = newDueDate;
                task.Category = newCategory;
                _context.SaveChanges(); // Save changes to the database
            }
        }

        public void MarkTaskAsComplete(int id)
        {
            var task = _context.TaskToDos.Find(id);
            if (task != null)
            {
                task.IsComplete = true;
                _context.SaveChanges();
            }
        }

        public void RemoveTask(int id)
        {
            var task = _context.TaskToDos.Find(id);
            if (task != null)
            {
                _context.TaskToDos.Remove(task);
                _context.SaveChanges();
            }
        }

        public List<TaskToDo> GetAllTasks()
        {
<<<<<<< HEAD
            return _context.TaskToDos.ToList(); 
=======
            return [.. _context.TaskToDos];
>>>>>>> 03e2d51abdeb477a3a23397c4e6eb9463da09bc5
        }
    }
}
