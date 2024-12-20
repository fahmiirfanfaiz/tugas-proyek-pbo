using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaskClass;
using TaskClass.Models;
using TaskSorterClass;

namespace ToDoListApp
{
    public partial class Form1 : Form
    {
        private readonly TaskManager taskManager;
        private readonly TaskSorter taskSorter;

        public Form1(TaskManager taskManager, TaskSorter taskSorter)
        {
            InitializeComponent();
            this.taskManager = taskManager;
            this.taskSorter = taskSorter;

            // Refresh task list on load
            RefreshTaskList().ConfigureAwait(false);
        }


        private async void btnAddTask_Click(object sender, EventArgs e)
        {
            var inputForm = new FormInputTask();
            if (inputForm.ShowDialog() == DialogResult.OK)
            {
                await taskManager.AddTask(
                    inputForm.Task.NameTask,
                    inputForm.Task.Description ?? null,
                    inputForm.Task.DueDate ?? DateTime.Today,
                    inputForm.Task.Category
                );
                await RefreshTaskList();
            }
        }

        private async void btnMarkComplete_Click(object sender, EventArgs e)
        {
            if (lstTasks.SelectedItem != null)
            {
                TaskToDo selectedTask = (TaskToDo)lstTasks.SelectedItem;
                await taskManager.MarkTaskAsComplete(selectedTask.Id);
                await RefreshTaskList();
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
                await taskManager.RemoveTask(selectedTask.Id);
                await RefreshTaskList();
            }
            else
            {
                MessageBox.Show("Please select a task to remove.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnSortByName_Click(object sender, EventArgs e)
        {
            lstTasks.Items.Clear();
            var tasks = await taskManager.GetAllTasks();
            var sortedTasks = taskSorter.SortTasksByName(tasks);
            foreach (var task in sortedTasks)
            {
                lstTasks.Items.Add(task);
            }
        }

        private async void btnSortByDueDate_Click(object sender, EventArgs e)
        {
            lstTasks.Items.Clear();
            var tasks = await taskManager.GetAllTasks();
            var sortedTasks = taskSorter.SortTasksByDueDate(tasks);
            foreach (var task in sortedTasks)
            {
                lstTasks.Items.Add(task);
            }
        }

        private async Task RefreshTaskList()
        {
            lstTasks.Items.Clear();
            var tasks = await taskManager.GetAllTasks();
            foreach (var task in tasks)
            {
                lstTasks.Items.Add(task);
            }
        }

        private void lstTasks_SelectedIndexChanged(object sender, EventArgs e)
        {

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
                    await taskManager.EditTask(
                        selectedTask.Id,
                        inputForm.Task.NameTask,
                        inputForm.Task.Description ?? null,
                        inputForm.Task.DueDate ?? DateTime.Today,
                        inputForm.Task.Category
                    );

                    await RefreshTaskList();
                }
            }
            else
            {
                MessageBox.Show("Please select a task to edit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void monthCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            // Handle date selection if needed
        }
    }
}

