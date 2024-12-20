using System;
using System.Windows.Forms;
using TaskClass.Models;

namespace ToDoListApp
{
    public partial class FormInputTask : Form
    {
        public TaskToDo Task { get; set; }

        public FormInputTask()
        {
            InitializeComponent();
            InitializeFormFields();
        }

        private void InitializeFormFields()
        {
            // Tambahkan kategori default
            comboBoxCategory.Items.AddRange(new string[] { "Personal", "Work", "School", "Other" });
            comboBoxCategory.SelectedIndex = 0; // Default category
            dateTimePickerDueDate.ShowCheckBox = true;
            dateTimePickerDueDate.Checked = false; // Default tidak memilih tanggal
        }

        // Validasi input sebelum menyimpan
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtNameTask.Text))
            {
                MessageBox.Show("Task name cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (comboBoxCategory.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a category.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validasi input
            if (!ValidateInput())
                return;

            // Buat task baru berdasarkan input
            Task = new TaskToDo
            {
                NameTask = txtNameTask.Text.Trim(),
                Description = string.IsNullOrWhiteSpace(txtDescription.Text) ? null : txtDescription.Text.Trim(),
                DueDate = dateTimePickerDueDate.Checked ? dateTimePickerDueDate.Value : (DateTime?)null,
                Category = comboBoxCategory.SelectedItem.ToString(),
                IsComplete = false // Default task belum selesai
            };

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txtNameTask_TextChanged(object sender, EventArgs e)
        {
            // Tambahkan logika di sini jika diperlukan.
        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            // Tambahkan logika di sini jika diperlukan.
        }

        private void FormInputTask_Load(object sender, EventArgs e)
        {
            // Tambahkan logika inisialisasi jika diperlukan.
        }

    }
}
