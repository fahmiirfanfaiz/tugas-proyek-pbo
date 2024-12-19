using System;
using System.Collections.Generic;
using System.Linq;

namespace TaskClass
{
    public class TaskManager
    {
        private List<TaskToDo> tasks;
        private int nextId;

        public TaskManager()
        {
            tasks = new List<TaskToDo>();
            nextId = 1;
        }

        public void AddTask(string nameTask, string description, DateTime dueDate, string category)
        {
            var newTask = new TaskToDo(nextId++, nameTask, description, dueDate, category);
            tasks.Add(newTask);
        }

        public void EditTask(int id, string newNameTask, string newDescription, DateTime newDueDate, string newCategory)
        {
            var task = tasks.Find(t => t.Id == id);
            if (task != null)
            {
                task.NameTask = newNameTask;
                task.Description = newDescription;
                task.DueDate = newDueDate;
                task.Category = newCategory;
            }
        }

        public void MarkTaskAsComplete(int id)
        {
            var task = tasks.Find(t => t.Id == id);
            if (task != null)
            {
                task.IsComplete = true;
            }
        }

        public List<TaskToDo> GetAllTasks()
        {
            return tasks.ToList();
        }

        public void RemoveTask(int id)
        {
            var task = tasks.Find(t => t.Id == id);
            if (task != null)
            {
                tasks.Remove(task);
            }
        }
    }
}
