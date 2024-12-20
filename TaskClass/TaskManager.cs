using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TaskClass.Models;

namespace TaskClass
{
    public class TaskManager
    {
        private readonly HttpClient _httpClient;

        public TaskManager(string baseAddress)
        {
            _httpClient = new HttpClient { BaseAddress = new Uri(baseAddress) };
        }

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

            var response = await _httpClient.PostAsJsonAsync("api/Tasks", task);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Failed to add task.");
            }
        }

        public async Task EditTask(int id, string newNameTask, string newDescription, DateTime newDueDate, string newCategory)
        {
            var task = new TaskToDo
            {
                Id = id,
                NameTask = newNameTask,
                Description = newDescription,
                DueDate = newDueDate,
                Category = newCategory
            };

            var response = await _httpClient.PutAsJsonAsync($"api/Tasks/{id}", task);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Failed to edit task.");
            }
        }

        public async Task MarkTaskAsComplete(int id)
        {
            var response = await _httpClient.PutAsync($"api/Tasks/Complete/{id}", null);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Failed to mark task as complete.");
            }
        }

        public async Task RemoveTask(int id)
        {
<<<<<<< HEAD
            var response = await _httpClient.DeleteAsync($"api/Tasks/{id}");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Failed to remove task.");
            }
        }

        public async Task<List<TaskToDo>> GetAllTasks()
        {
            var response = await _httpClient.GetAsync("api/Tasks");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<TaskToDo>>();
            }
            else
            {
                throw new Exception("Failed to retrieve tasks.");
            }
=======
<<<<<<< HEAD
            return _context.TaskToDos.ToList(); 
=======
            return [.. _context.TaskToDos];
>>>>>>> 03e2d51abdeb477a3a23397c4e6eb9463da09bc5
>>>>>>> be94fbaf434698a0e0b720247a98dfc18b2d0ea6
        }
    }
}
