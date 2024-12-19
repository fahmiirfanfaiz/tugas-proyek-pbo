using System.Collections.Generic;
using System.Linq;
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
            return _context.TaskToDos.ToList();
        }
    }
}
