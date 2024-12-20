using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskClass.Models;

namespace TaskClass
{
    public class TaskManager
    {
        private readonly HttpClient _httpClient;
        private readonly ToDoListDbContext _context;

        public TaskManager(HttpClient httpClient, ToDoListDbContext context)
        {
            _httpClient = httpClient;
            _context = context;
        }

        /// <summary>
        /// Adds a new task to the database and API.
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

            // Add to database
            await _context.TaskToDos.AddAsync(task);
            await _context.SaveChangesAsync();

            // Add to API
            var response = await _httpClient.PostAsJsonAsync("api/Tasks", task);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Failed to add task to API.");
            }
        }

        /// <summary>
        /// Edits an existing task in the database and API.
        /// </summary>
        public async Task EditTask(int id, string newNameTask, string newDescription, DateTime newDueDate, string newCategory)
        {
            var task = await _context.TaskToDos.FindAsync(id);
            if (task != null)
            {
                task.NameTask = newNameTask;
                task.Description = newDescription;
                task.DueDate = newDueDate;
                task.Category = newCategory;
                await _context.SaveChangesAsync();

                // Update in API
                var response = await _httpClient.PutAsJsonAsync($"api/Tasks/{id}", task);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Failed to edit task in API.");
                }
            }
        }

        /// <summary>
        /// Marks a task as complete in the database and API.
        /// </summary>
        public async Task MarkTaskAsComplete(int id)
        {
            var task = await _context.TaskToDos.FindAsync(id);
            if (task != null)
            {
                task.IsComplete = true;
                await _context.SaveChangesAsync();

                // Update in API
                var response = await _httpClient.PutAsync($"api/Tasks/Complete/{id}", null);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Failed to mark task as complete in API.");
                }
            }
        }

        /// <summary>
        /// Removes a task from the database and API.
        /// </summary>
        public async Task RemoveTask(int id)
        {
            var task = await _context.TaskToDos.FindAsync(id);
            if (task != null)
            {
                _context.TaskToDos.Remove(task);
                await _context.SaveChangesAsync();

                // Remove from API
                var response = await _httpClient.DeleteAsync($"api/Tasks/{id}");
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Failed to remove task from API.");
                }
            }
        }

        /// <summary>
        /// Gets all tasks from the database.
        /// </summary>
        public async Task<List<TaskToDo>> GetAllTasks()
        {
            return await _context.TaskToDos.ToListAsync();
        }
    }
}
