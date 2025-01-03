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

        public Form1()
        {
            InitializeComponent();
            var optionsBuilder = new DbContextOptionsBuilder<ToDoListDbContext>();
            optionsBuilder.UseSqlServer("Data Source=LAPTOP-2D8G3I8L\\SQLEXPRESS;Initial Catalog=ToDoListDB;Integrated Security=True;Pooling=False;Encrypt=False;Trust Server Certificate=True");
            var context = new ToDoListDbContext(optionsBuilder.Options);

            var httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:5151/api/")
            };

            taskManager = new TaskManager(httpClient, context);
            taskSorter = new TaskSorter();
            RefreshTaskList();

            // Set form background color
            this.BackColor = System.Drawing.Color.LightBlue;

            // Customize buttons
            foreach (Control control in this.Controls)
            {
                if (control is Button button)
                {
                    button.BackColor = System.Drawing.Color.SteelBlue;
                    button.ForeColor = System.Drawing.Color.White;
                    button.FlatStyle = FlatStyle.Flat;
                    button.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue;
                }
            }

            // Customize list box
            lstTasks.BackColor = System.Drawing.Color.AliceBlue;
            lstTasks.ForeColor = System.Drawing.Color.DarkBlue;
            lstTasks.BorderStyle = BorderStyle.FixedSingle;

            // Customize other controls as needed
            // Example: monthCalendar
            monthCalendar.TitleBackColor = System.Drawing.Color.SteelBlue;
            monthCalendar.TitleForeColor = System.Drawing.Color.White;
            monthCalendar.TrailingForeColor = System.Drawing.Color.DarkBlue;
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

        private async void btnEditTask_Click(object sender, EventArgs e)
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
            
        }

        private void monthCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {

        }
    }
}


