namespace ToDoListApp
{
    partial class FormInputTask
    {
        private System.ComponentModel.IContainer components = null;

        // Members UI
        private System.Windows.Forms.TextBox txtNameTask;
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
            txtNameTask = new TextBox();
            txtDescription = new TextBox();
            dateTimePickerDueDate = new DateTimePicker();
            comboBoxCategory = new ComboBox();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // txtNameTask
            // 
            txtNameTask.Location = new Point(20, 20);
            txtNameTask.Name = "txtNameTask";
            txtNameTask.PlaceholderText = "Enter task...";
            txtNameTask.Size = new Size(250, 27);
            txtNameTask.TabIndex = 0;
            txtNameTask.TextChanged += txtNameTask_TextChanged;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(20, 50);
            txtDescription.Name = "txtDescription";
            txtDescription.PlaceholderText = "Enter task description...";
            txtDescription.Size = new Size(250, 27);
            txtDescription.TabIndex = 0;
            txtDescription.TextChanged += txtDescription_TextChanged;
            // 
            // dateTimePickerDueDate
            // 
            dateTimePickerDueDate.Location = new Point(20, 80);
            dateTimePickerDueDate.Name = "dateTimePickerDueDate";
            dateTimePickerDueDate.Size = new Size(250, 27);
            dateTimePickerDueDate.TabIndex = 1;
            // 
            // comboBoxCategory
            // 
            comboBoxCategory.Items.AddRange(new object[] { "Work", "Personal", "School", "Other" });
            comboBoxCategory.Location = new Point(20, 110);
            comboBoxCategory.Name = "comboBoxCategory";
            comboBoxCategory.Size = new Size(250, 28);
            comboBoxCategory.TabIndex = 2;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(50, 150);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 33);
            btnSave.TabIndex = 3;
            btnSave.Text = "Save";
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(150, 150);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 33);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Cancel";
            btnCancel.Click += btnCancel_Click;
            // 
            // FormInputTask
            // 
            ClientSize = new Size(300, 200);
            Controls.Add(txtNameTask);
            Controls.Add(txtDescription);
            Controls.Add(dateTimePickerDueDate);
            Controls.Add(comboBoxCategory);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            Name = "FormInputTask";
            Text = "Add New Task";
            Load += FormInputTask_Load;
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
