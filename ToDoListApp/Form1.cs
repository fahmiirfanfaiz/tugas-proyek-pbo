using Microsoft.EntityFrameworkCore;
using System;
using System.Windows.Forms;
using TaskClass;
using TaskClass.Models;

namespace ToDoListApp
{
    public partial class Form1 : Form
    {
        private TaskManager taskManager;

        public Form1()
        {
            InitializeComponent();
            var optionsBuilder = new DbContextOptionsBuilder<ToDoListDbContext>();
            optionsBuilder.UseSqlServer("Data Source=LAPTOP-2D8G3I8L\\SQLEXPRESS;Initial Catalog=ToDoListDB;Integrated Security=True;Pooling=False;Encrypt=False;Trust Server Certificate=True");
            var context = new ToDoListDbContext(optionsBuilder.Options);
            taskManager = new TaskManager(context);
            RefreshTaskList();
        }

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            var inputForm = new FormInputTask();
            if (inputForm.ShowDialog() == DialogResult.OK)
            {
                taskManager.AddTask(
                    inputForm.Task.NameTask,
                    inputForm.Task.Description ?? null,
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
            foreach (var task in taskManager.GetAllTasks())
            {
                lstTasks.Items.Add(task);
            }
        }

        private void lstTasks_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Edit_Click(object sender, EventArgs e)
        {

        }
    }
}
