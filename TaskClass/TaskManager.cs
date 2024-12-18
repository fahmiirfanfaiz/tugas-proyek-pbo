using System;
using System.Collections.Generic;
using System.Linq;
using TaskClass;

namespace ToDoListApp
{
    public class TaskManager
    {
        private readonly ToDoDbContext _context;

        // Constructor untuk inisialisasi DbContext
        public TaskManager()
        {
            _context = new ToDoDbContext();
        }

        // Menambahkan task baru ke database
        public void AddTask(string name, string description, DateTime dueDate, string category)
        {
            var task = new TaskToDo
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

        // Mengambil semua task dari database
        public List<TaskToDo> GetAllTasks()
        {
            return _context.Tasks.ToList();
        }

        // Menandai task sebagai selesai berdasarkan id
        public void MarkTaskAsComplete(int id)
        {
            var task = _context.Tasks.Find(id);
            if (task != null)
            {
                task.IsComplete = true;
                _context.SaveChanges();
            }
        }

        // Menghapus task berdasarkan id
        public void RemoveTask(int id)
        {
            var task = _context.Tasks.Find(id);
            if (task != null)
            {
                _context.Tasks.Remove(task);
                _context.SaveChanges();
            }
        }

        // Mengupdate task yang ada di database
        public void UpdateTask(TaskToDo updatedTask)
        {
            var task = _context.Tasks.Find(updatedTask.Id);
            if (task != null)
            {
                task.NameTask = updatedTask.NameTask;
                task.Description = updatedTask.Description;
                task.DueDate = updatedTask.DueDate;
                task.Category = updatedTask.Category;
                task.IsComplete = updatedTask.IsComplete;

                _context.SaveChanges();
            }
        }
    }
}
