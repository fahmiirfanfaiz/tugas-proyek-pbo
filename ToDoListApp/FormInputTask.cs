using System;
using System.Windows.Forms;
using TaskClass;

namespace ToDoListApp
{
    public partial class FormInputTask : Form
    {
        public TaskToDo Task { get; private set; }

        public FormInputTask()
        {
            InitializeComponent();
            comboBoxCategory.Items.AddRange(new string[] { "Personal", "Work", "School", "Other" });
            comboBoxCategory.SelectedIndex = 0; // Default kategori
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                MessageBox.Show("Please enter a task description.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Task = new TaskToDo(
                id: 0,
                description: txtDescription.Text,
                dueDate: dateTimePickerDueDate.Value,
                category: comboBoxCategory.SelectedItem.ToString()
            );

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
