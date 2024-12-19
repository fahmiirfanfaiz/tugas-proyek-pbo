using System;
using System.Windows.Forms;
using TaskClass;
using TaskClass.Models;

namespace ToDoListApp
{
    public partial class FormInputTask : Form
    {
        public TaskToDo Task { get; private set; }

        public FormInputTask()
        {
            InitializeComponent();
            comboBoxCategory.Items.AddRange(new string[] { "Personal", "Work", "School", "Other" });
            comboBoxCategory.SelectedIndex = 0; // Default category
            dateTimePickerDueDate.ShowCheckBox = true; // Allow null value for DueDate
        }

        // Method to validate input fields
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtNameTask.Text))
            {
                MessageBox.Show("Task name cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validate the input fields before saving
            if (!ValidateInput())
                return;

            // Create a new task with the values from the input fields
            Task = new TaskToDo
            {
                NameTask = txtNameTask.Text,
                Description = string.IsNullOrWhiteSpace(txtDescription.Text) ? null : txtDescription.Text,
                DueDate = dateTimePickerDueDate.Checked ? dateTimePickerDueDate.Value : (DateTime?)null,
                Category = comboBoxCategory.Text
            };

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void FormInputTask_Load(object sender, EventArgs e)
        {

        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNameTask_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

