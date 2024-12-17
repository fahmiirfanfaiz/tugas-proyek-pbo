using System;
using System.Windows.Forms;
using TaskClass;

namespace ToDoListApp
{
    public partial class Form1 : Form
    {
        private TaskManager taskManager;

        public Form1()
        {
            InitializeComponent();
            taskManager = new TaskManager();
            RefreshTaskList();
        }

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            var inputForm = new FormInputTask();
            if (inputForm.ShowDialog() == DialogResult.OK)
            {
                taskManager.AddTask(
                    inputForm.Task.Description,
                    inputForm.Task.DueDate,
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
                lstTasks.Items.Add(task.ToString());
            }
        }

        private void txtNewTask_TextChanged(object sender, EventArgs e)
        {

        }

        private void lstTasks_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Edit_Click(object sender, EventArgs e)
        {
                
        }

    }
}

