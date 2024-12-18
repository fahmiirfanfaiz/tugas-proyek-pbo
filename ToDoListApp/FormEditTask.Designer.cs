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
            this.txtNameTask = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.dateTimePickerDueDate = new System.Windows.Forms.DateTimePicker();
            this.comboBoxCategory = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblNameTask = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblDueDate = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtNameTask
            // 
            this.txtNameTask.Location = new System.Drawing.Point(120, 30);
            this.txtNameTask.Name = "txtNameTask";
            this.txtNameTask.Size = new System.Drawing.Size(200, 22);
            this.txtNameTask.TabIndex = 0;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(120, 70);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(200, 60);
            this.txtDescription.TabIndex = 1;
            // 
            // dateTimePickerDueDate
            // 
            this.dateTimePickerDueDate.Location = new System.Drawing.Point(120, 150);
            this.dateTimePickerDueDate.Name = "dateTimePickerDueDate";
            this.dateTimePickerDueDate.Size = new System.Drawing.Size(200, 22);
            this.dateTimePickerDueDate.TabIndex = 2;
            // 
            // comboBoxCategory
            // 
            this.comboBoxCategory.FormattingEnabled = true;
            this.comboBoxCategory.Location = new System.Drawing.Point(120, 190);
            this.comboBoxCategory.Name = "comboBoxCategory";
            this.comboBoxCategory.Size = new System.Drawing.Size(200, 24);
            this.comboBoxCategory.TabIndex = 3;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(120, 230);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 30);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(200, 230);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 30);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblNameTask
            // 
            this.lblNameTask.AutoSize = true;
            this.lblNameTask.Location = new System.Drawing.Point(30, 30);
            this.lblNameTask.Name = "lblNameTask";
            this.lblNameTask.Size = new System.Drawing.Size(84, 17);
            this.lblNameTask.TabIndex = 6;
            this.lblNameTask.Text = "Task Name:";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(30, 70);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(79, 17);
            this.lblDescription.TabIndex = 7;
            this.lblDescription.Text = "Description:";
            // 
            // lblDueDate
            // 
            this.lblDueDate.AutoSize = true;
            this.lblDueDate.Location = new System.Drawing.Point(30, 150);
            this.lblDueDate.Name = "lblDueDate";
            this.lblDueDate.Size = new System.Drawing.Size(68, 17);
            this.lblDueDate.TabIndex = 8;
            this.lblDueDate.Text = "Due Date:";
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(30, 190);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(68, 17);
            this.lblCategory.TabIndex = 9;
            this.lblCategory.Text = "Category:";
            // 
            // FormEditTask
            // 
            this.ClientSize = new System.Drawing.Size(350, 280);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.lblDueDate);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblNameTask);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.comboBoxCategory);
            this.Controls.Add(this.dateTimePickerDueDate);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtNameTask);
            this.Name = "FormEditTask";
            this.Text = "Edit Task";
            this.ResumeLayout(false);
            this.PerformLayout();
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
