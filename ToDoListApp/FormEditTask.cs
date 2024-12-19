using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TaskClass;

namespace ToDoListApp
{
    public partial class FormEditTask : Form
    {
        private TaskToDo currentTask;

        // Event declaration for when a task is edited
        public event Action<TaskToDo> OnTaskEdited;

        public FormEditTask(TaskToDo task)
        {
            InitializeComponent();
            currentTask = task;

            // Set data to input fields
            txtNameTask.Text = task.NameTask;
            txtDescription.Text = task.Description;
            dateTimePickerDueDate.Value = task.DueDate;
            comboBoxCategory.Text = task.Category;

            // Set button texts for clarity
            btnSave.Text = "&Save"; // Save button with shortcut Alt+S
            btnCancel.Text = "&Cancel"; // Cancel button with shortcut Alt+C
        }

        // Save button click to update the task
        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validate the input fields before saving
            if (!ValidateInput())
                return;

            // Update the task data with the values from the input fields
            currentTask.NameTask = txtNameTask.Text;
            currentTask.Description = txtDescription.Text;
            currentTask.DueDate = dateTimePickerDueDate.Value;
            currentTask.Category = comboBoxCategory.Text;

            // Trigger event callback to notify that the task has been edited
            OnTaskEdited?.Invoke(currentTask);

            // Notify user and close the form after editing
            MessageBox.Show("Task has been successfully updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        // Cancel button click to close the form without saving changes
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Method to set the list of categories dynamically
        public void SetCategories(List<string> categories)
        {
            comboBoxCategory.DataSource = categories;
        }

        // Method to validate input fields
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtNameTask.Text))
            {
                MessageBox.Show("Task name cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (dateTimePickerDueDate.Value < DateTime.Now)
            {
                MessageBox.Show("Due date cannot be in the past.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void FormEditTask_Load(object sender, EventArgs e)
        {

        }
    }
}
