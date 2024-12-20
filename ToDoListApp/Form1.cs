using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaskClass.Models;
using TaskSorter;

namespace ToDoListApp
{
    public partial class Form1 : Form
    {
<<<<<<< HEAD
        public Form1()
        {
            InitializeComponent();
=======
        private TaskManager taskManager;
        private TaskSorterService taskSorterService;

        public Form1()
        {
            InitializeComponent();
            var optionsBuilder = new DbContextOptionsBuilder<ToDoListDbContext>();
            optionsBuilder.UseSqlServer("Data Source=LAPTOP-2D8G3I8L\\SQLEXPRESS;Initial Catalog=ToDoListDB;Integrated Security=True;Pooling=False;Encrypt=False;Trust Server Certificate=True");
            var context = new ToDoListDbContext(optionsBuilder.Options);
            taskManager = new TaskManager(context);
            taskSorterService = new TaskSorterService();
>>>>>>> be94fbaf434698a0e0b720247a98dfc18b2d0ea6
            RefreshTaskList();
        }

        private async void RefreshTaskList()
        {
            lstTasks.Items.Clear();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5000/api/");
                var response = await client.GetAsync("Tasks");
                if (response.IsSuccessStatusCode)
                {
                    var tasks = await response.Content.ReadFromJsonAsync<List<TaskToDo>>();
                    if (tasks != null)
                    {
                        foreach (var task in tasks)
                        {
                            lstTasks.Items.Add(task);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Failed to load tasks.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void btnAddTask_Click(object sender, EventArgs e)
        {
            var inputForm = new FormInputTask();
            if (inputForm.ShowDialog() == DialogResult.OK)
            {
<<<<<<< HEAD
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:5000/api/");
                    var response = await client.PostAsJsonAsync("Tasks", inputForm.Task);
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Task added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefreshTaskList();
                    }
                    else
                    {
                        MessageBox.Show("Failed to add task.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
=======
                taskManager.AddTask(
                    inputForm.Task.NameTask,
                    inputForm.Task.Description ?? string.Empty,
                    inputForm.Task.DueDate ?? DateTime.Today,
                    inputForm.Task.Category
                );
                RefreshTaskList();
>>>>>>> be94fbaf434698a0e0b720247a98dfc18b2d0ea6
            }
        }

        private async void btnMarkComplete_Click(object sender, EventArgs e)
        {
            if (lstTasks.SelectedItem != null)
            {
                TaskToDo selectedTask = (TaskToDo)lstTasks.SelectedItem;

                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:5000/api/");
                    var response = await client.PutAsync($"Tasks/Complete/{selectedTask.Id}", null);
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Task marked as complete!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefreshTaskList();
                    }
                    else
                    {
                        MessageBox.Show("Failed to mark task as complete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a task to mark as complete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnRemoveTask_Click(object sender, EventArgs e)
        {
            if (lstTasks.SelectedItem != null)
            {
                TaskToDo selectedTask = (TaskToDo)lstTasks.SelectedItem;

                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:5000/api/");
                    var response = await client.DeleteAsync($"Tasks/{selectedTask.Id}");
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Task removed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefreshTaskList();
                    }
                    else
                    {
                        MessageBox.Show("Failed to remove task.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a task to remove.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

<<<<<<< HEAD
        private async void Edit_Click(object sender, EventArgs e)
=======
        private void RefreshTaskList()
        {
            lstTasks.Items.Clear();
            var tasks = taskManager.GetAllTasks();
            var taskToDo2List = tasks.Select(t => new TaskToDo_2
            {
                NameTask = t.NameTask,
                Description = t.Description,
                DueDate = t.DueDate,
                Category = t.Category,
                IsComplete = t.IsComplete
            }).ToList();
            var sortedTasks = taskSorterService.GetSortedTasks(taskToDo2List);
            foreach (var task in sortedTasks)
            {
                lstTasks.Items.Add(task);
            }
        }

        private void lstTasks_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Edit_Click(object sender, EventArgs e)
>>>>>>> be94fbaf434698a0e0b720247a98dfc18b2d0ea6
        {
            if (lstTasks.SelectedItem != null)
            {
                TaskToDo selectedTask = (TaskToDo)lstTasks.SelectedItem;

                var inputForm = new FormInputTask
                {
                    Task = new TaskToDo(
                        selectedTask.Id,
                        selectedTask.NameTask,
                        selectedTask.Description,
                        selectedTask.DueDate ?? DateTime.Today,
                        selectedTask.Category
                    )
                };

                if (inputForm.ShowDialog() == DialogResult.OK)
                {
<<<<<<< HEAD
                    using (HttpClient client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("http://localhost:5000/api/");
                        var response = await client.PutAsJsonAsync($"Tasks/{selectedTask.Id}", inputForm.Task);
                        if (response.IsSuccessStatusCode)
                        {
                            MessageBox.Show("Task updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            RefreshTaskList();
                        }
                        else
                        {
                            MessageBox.Show("Failed to update task.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
=======
                    // Update the task with the new data
                    taskManager.EditTask(
                        selectedTask.Id,
                        inputForm.Task.NameTask,
                        inputForm.Task.Description ?? string.Empty,
                        inputForm.Task.DueDate ?? DateTime.Today, // Convert nullable to non-nullable
                        inputForm.Task.Category
                    );

                    RefreshTaskList();
>>>>>>> be94fbaf434698a0e0b720247a98dfc18b2d0ea6
                }
            }
            else
            {
                MessageBox.Show("Please select a task to edit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

<<<<<<< HEAD
        private void lstTasks_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Tambahkan logika inisialisasi jika diperlukan.
=======
        private void Form1_Load(object sender, EventArgs e)
        {

>>>>>>> be94fbaf434698a0e0b720247a98dfc18b2d0ea6
        }
    }
}
