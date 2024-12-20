using Microsoft.EntityFrameworkCore;
using System;
using System.Windows.Forms;
using TaskClass;
using TaskClass.Models;
using TaskSorter;

namespace ToDoListApp
{
    public partial class Form1 : Form
    {
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
            RefreshTaskList();
        }

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            var inputForm = new FormInputTask();
            if (inputForm.ShowDialog() == DialogResult.OK)
            {
                taskManager.AddTask(
                    inputForm.Task.NameTask,
                    inputForm.Task.Description ?? string.Empty,
                    inputForm.Task.DueDate ?? DateTime.Today,
                    inputForm.Task.Category
                );
                RefreshTaskList();
            }
        }

        private void btnMarkComplete_Click(object sender, EventArgs e)
        {
            if (lstTasks.SelectedItem != null)
            {
                TaskToDo selectedTask = (TaskToDo)lstTasks.SelectedItem;
                taskManager.MarkTaskAsComplete(selectedTask.Id);
                RefreshTaskList();
            }
            else
            {
                MessageBox.Show("Please select a task to mark as complete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemoveTask_Click(object sender, EventArgs e)
        {
            if (lstTasks.SelectedItem != null)
            {
                TaskToDo selectedTask = (TaskToDo)lstTasks.SelectedItem;
                taskManager.RemoveTask(selectedTask.Id);
                RefreshTaskList();
            }
            else
            {
                MessageBox.Show("Please select a task to remove.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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
        {
            if (lstTasks.SelectedItem != null)
            {
                // Retrieve the selected task
                TaskToDo selectedTask = (TaskToDo)lstTasks.SelectedItem;

                // Open FormInputTask with the selected task data
                var inputForm = new FormInputTask
                {
                    Task = new TaskToDo(
                        selectedTask.Id,
                        selectedTask.NameTask,
                        selectedTask.Description,
                        selectedTask.DueDate ?? DateTime.Today, // Convert nullable to non-nullable
                        selectedTask.Category
                    )
                };

                if (inputForm.ShowDialog() == DialogResult.OK)
                {
                    // Update the task with the new data
                    taskManager.EditTask(
                        selectedTask.Id,
                        inputForm.Task.NameTask,
                        inputForm.Task.Description ?? string.Empty,
                        inputForm.Task.DueDate ?? DateTime.Today, // Convert nullable to non-nullable
                        inputForm.Task.Category
                    );

                    RefreshTaskList();
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
    }
}
