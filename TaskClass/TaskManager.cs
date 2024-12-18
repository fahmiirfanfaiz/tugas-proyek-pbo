using System.Collections.Generic;
using System.Linq;
using TaskClass;

namespace ToDoListApp
{
    public class TaskManager
    {
        private readonly ToDoDbContext _context;

        public TaskManager()
        {
            _context = new ToDoDbContext();
        }

        public void AddTask(string name, string description, DateTime dueDate, string category)
        {
            var task = new TaskToDo // Gunakan constructor default dan inisialisasi properti.
            {
                NameTask = name,
                Description = description,
                DueDate = dueDate,
                Category = category,
                IsComplete = false
            };
            _context.Tasks.Add(task);
            _context.SaveChanges();
        }

        public List<TaskToDo> GetAllTasks()
        {
            return _context.Tasks.ToList();
        }

        public void MarkTaskAsComplete(int id)
        {
            var task = _context.Tasks.Find(id);
            if (task != null)
            {
                task.IsComplete = true;
                _context.SaveChanges();
            }
        }

        public void RemoveTask(int id)
        {
            var task = _context.Tasks.Find(id);
            if (task != null)
            {
                _context.Tasks.Remove(task);
                _context.SaveChanges();
            }
        }
    }
}
