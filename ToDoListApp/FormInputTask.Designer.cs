namespace ToDoListApp
{
    partial class FormInputTask
    {
        private System.ComponentModel.IContainer components = null;

        // Members UI
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.DateTimePicker dateTimePickerDueDate;
        private System.Windows.Forms.ComboBox comboBoxCategory;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.dateTimePickerDueDate = new System.Windows.Forms.DateTimePicker();
            this.comboBoxCategory = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();

            // Form Properties
            this.SuspendLayout();
            this.Text = "Add New Task";
            this.ClientSize = new System.Drawing.Size(300, 200);

            // txtDescription
            this.txtDescription.Location = new System.Drawing.Point(20, 20);
            this.txtDescription.Size = new System.Drawing.Size(250, 20);
            this.txtDescription.PlaceholderText = "Enter task description...";

            // dateTimePickerDueDate
            this.dateTimePickerDueDate.Location = new System.Drawing.Point(20, 50);
            this.dateTimePickerDueDate.Size = new System.Drawing.Size(250, 20);

            // comboBoxCategory
            this.comboBoxCategory.Items.AddRange(new string[] { "Work", "Personal", "School", "Other" });
            this.comboBoxCategory.Location = new System.Drawing.Point(20, 80);
            this.comboBoxCategory.Size = new System.Drawing.Size(250, 21);
            this.comboBoxCategory.SelectedIndex = 0;

            // btnSave
            this.btnSave.Location = new System.Drawing.Point(50, 120);
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // btnCancel
            this.btnCancel.Location = new System.Drawing.Point(150, 120);
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // Add Controls
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.dateTimePickerDueDate);
            this.Controls.Add(this.comboBoxCategory);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
