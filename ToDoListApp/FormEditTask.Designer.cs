namespace ToDoListApp
{
    partial class FormEditTask
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">True if managed resources should be disposed; otherwise, False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            txtNameTask = new TextBox();
            txtDescription = new TextBox();
            dateTimePickerDueDate = new DateTimePicker();
            comboBoxCategory = new ComboBox();
            btnSave = new Button();
            btnCancel = new Button();
            lblNameTask = new Label();
            lblDescription = new Label();
            lblDueDate = new Label();
            lblCategory = new Label();
            SuspendLayout();
            // 
            // txtNameTask
            // 
            txtNameTask.Location = new Point(120, 30);
            txtNameTask.Name = "txtNameTask";
            txtNameTask.Size = new Size(200, 27);
            txtNameTask.TabIndex = 0;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(120, 70);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(200, 60);
            txtDescription.TabIndex = 1;
            // 
            // dateTimePickerDueDate
            // 
            dateTimePickerDueDate.Location = new Point(120, 150);
            dateTimePickerDueDate.Name = "dateTimePickerDueDate";
            dateTimePickerDueDate.Size = new Size(200, 27);
            dateTimePickerDueDate.TabIndex = 2;
            // 
            // comboBoxCategory
            // 
            comboBoxCategory.FormattingEnabled = true;
            comboBoxCategory.Location = new Point(120, 190);
            comboBoxCategory.Name = "comboBoxCategory";
            comboBoxCategory.Size = new Size(200, 28);
            comboBoxCategory.TabIndex = 3;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(120, 230);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 30);
            btnSave.TabIndex = 4;
            btnSave.Text = "&Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(200, 230);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 30);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "&Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // lblNameTask
            // 
            lblNameTask.AutoSize = true;
            lblNameTask.Location = new Point(30, 30);
            lblNameTask.Name = "lblNameTask";
            lblNameTask.Size = new Size(83, 20);
            lblNameTask.TabIndex = 6;
            lblNameTask.Text = "Task Name:";
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Location = new Point(30, 70);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(88, 20);
            lblDescription.TabIndex = 7;
            lblDescription.Text = "Description:";
            // 
            // lblDueDate
            // 
            lblDueDate.AutoSize = true;
            lblDueDate.Location = new Point(30, 150);
            lblDueDate.Name = "lblDueDate";
            lblDueDate.Size = new Size(75, 20);
            lblDueDate.TabIndex = 8;
            lblDueDate.Text = "Due Date:";
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Location = new Point(30, 190);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(72, 20);
            lblCategory.TabIndex = 9;
            lblCategory.Text = "Category:";
            // 
            // FormEditTask
            // 
            ClientSize = new Size(350, 280);
            Controls.Add(lblCategory);
            Controls.Add(lblDueDate);
            Controls.Add(lblDescription);
            Controls.Add(lblNameTask);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(comboBoxCategory);
            Controls.Add(dateTimePickerDueDate);
            Controls.Add(txtDescription);
            Controls.Add(txtNameTask);
            Name = "FormEditTask";
            Text = "Edit Task";
            Load += FormEditTask_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox txtNameTask;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.DateTimePicker dateTimePickerDueDate;
        private System.Windows.Forms.ComboBox comboBoxCategory;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblNameTask;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblDueDate;
        private System.Windows.Forms.Label lblCategory;
    }
}
