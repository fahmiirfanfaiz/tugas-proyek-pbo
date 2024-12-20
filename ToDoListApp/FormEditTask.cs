using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TaskClass;
using TaskClass.Models;

namespace ToDoListApp
{
    public partial class FormEditTask : Form
    {
        private TaskToDo currentTask;

        // Event declaration for when a task is edited
        public event Action<TaskToDo> OnTaskEdited;

        public FormEditTask(TaskToDo task)
        {
            if (task == null)
                throw new ArgumentNullException(nameof(task), "Task cannot be null.");

            InitializeComponent();
            currentTask = task;

            // Set data to input fields
            txtNameTask.Text = task.NameTask;
            txtDescription.Text = task.Description ?? string.Empty;
            dateTimePickerDueDate.Value = task.DueDate ?? DateTime.Now;
            dateTimePickerDueDate.Checked = task.DueDate.HasValue;
            comboBoxCategory.Text = task.Category;

            // Set button texts for clarity
            btnSave.Text = "&Save"; // Save button with shortcut Alt+S
            btnCancel.Text = "&Cancel"; // Cancel button with shortcut Alt+C
        }

        private void FormEditTask_Load(object sender, EventArgs e)
        {
        }

        // Save button click to update the task
        private void btnSave_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = false; // Disable tombol selama proses
            btnCancel.Enabled = false;

            try
            {
                // Validate the input fields before saving
                if (!ValidateInput())
                    return;

                // Update the task data with the values from the input fields
                currentTask.NameTask = txtNameTask.Text;
                currentTask.Description = string.IsNullOrWhiteSpace(txtDescription.Text) ? null : txtDescription.Text;
                currentTask.DueDate = dateTimePickerDueDate.Checked ? dateTimePickerDueDate.Value : (DateTime?)null;
                currentTask.Category = comboBoxCategory.Text;

                // Trigger event callback to notify that the task has been edited
                OnTaskEdited?.Invoke(currentTask);

                // Notify user and close the form after editing
                this.Invoke((MethodInvoker)delegate
                {
                    MessageBox.Show("Task has been successfully updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to save task. Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnSave.Enabled = true; // Enable kembali tombol
                btnCancel.Enabled = true;
            }
        }

        // Cancel button click to close the form without saving changes
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Method to set the list of categories dynamically
        public void SetCategories(List<string> categories)
        {
            if (categories == null || categories.Count == 0)
            {
                comboBoxCategory.DataSource = new List<string> { "No categories available" };
                comboBoxCategory.Enabled = false; // Nonaktifkan dropdown jika kosong
            }
            else
            {
                comboBoxCategory.DataSource = categories;
                comboBoxCategory.Enabled = true;
            }
        }

        // Method to validate input fields
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtNameTask.Text))
            {
                MessageBox.Show("Task name cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (comboBoxCategory.Items.Count > 0 && !comboBoxCategory.Items.Contains(comboBoxCategory.Text))
            {
                MessageBox.Show("Invalid category selected.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
    }
}
