using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaskClass.Models;

namespace ToDoListApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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

        private async void Edit_Click(object sender, EventArgs e)
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
                }
            }
            else
            {
                MessageBox.Show("Please select a task to edit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lstTasks_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Tambahkan logika inisialisasi jika diperlukan.
        }
    }
}
