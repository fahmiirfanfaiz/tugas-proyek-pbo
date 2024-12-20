namespace ToDoListApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnAddTask;
        private System.Windows.Forms.Button btnMarkComplete;
        private System.Windows.Forms.Button btnRemoveTask;
        private System.Windows.Forms.Button btnSortByName;
        private System.Windows.Forms.Button btnSortByDueDate;
        private System.Windows.Forms.ListBox lstTasks;
        private System.Windows.Forms.MonthCalendar monthCalendar;

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
            this.btnAddTask = new System.Windows.Forms.Button();
            this.btnMarkComplete = new System.Windows.Forms.Button();
            this.btnRemoveTask = new System.Windows.Forms.Button();
            this.btnSortByName = new System.Windows.Forms.Button();
            this.btnSortByDueDate = new System.Windows.Forms.Button();
            this.lstTasks = new System.Windows.Forms.ListBox();
            this.monthCalendar = new System.Windows.Forms.MonthCalendar();
            this.SuspendLayout();
            // 
            // btnAddTask
            // 
            this.btnAddTask.Location = new System.Drawing.Point(12, 12);
            this.btnAddTask.Name = "btnAddTask";
            this.btnAddTask.Size = new System.Drawing.Size(75, 23);
            this.btnAddTask.TabIndex = 0;
            this.btnAddTask.Text = "Add Task";
            this.btnAddTask.UseVisualStyleBackColor = true;
            this.btnAddTask.Click += new System.EventHandler(this.btnAddTask_Click);
            // 
            // btnMarkComplete
            // 
            this.btnMarkComplete.Location = new System.Drawing.Point(93, 12);
            this.btnMarkComplete.Name = "btnMarkComplete";
            this.btnMarkComplete.Size = new System.Drawing.Size(100, 23);
            this.btnMarkComplete.TabIndex = 1;
            this.btnMarkComplete.Text = "Mark Complete";
            this.btnMarkComplete.UseVisualStyleBackColor = true;
            this.btnMarkComplete.Click += new System.EventHandler(this.btnMarkComplete_Click);
            // 
            // btnRemoveTask
            // 
            this.btnRemoveTask.Location = new System.Drawing.Point(199, 12);
            this.btnRemoveTask.Name = "btnRemoveTask";
            this.btnRemoveTask.Size = new System.Drawing.Size(100, 23);
            this.btnRemoveTask.TabIndex = 2;
            this.btnRemoveTask.Text = "Remove Task";
            this.btnRemoveTask.UseVisualStyleBackColor = true;
            this.btnRemoveTask.Click += new System.EventHandler(this.btnRemoveTask_Click);
            // 
            // btnSortByName
            // 
            this.btnSortByName.Location = new System.Drawing.Point(305, 12);
            this.btnSortByName.Name = "btnSortByName";
            this.btnSortByName.Size = new System.Drawing.Size(100, 23);
            this.btnSortByName.TabIndex = 3;
            this.btnSortByName.Text = "Sort by Name";
            this.btnSortByName.UseVisualStyleBackColor = true;
            this.btnSortByName.Click += new System.EventHandler(this.btnSortByName_Click);
            // 
            // btnSortByDueDate
            // 
            this.btnSortByDueDate.Location = new System.Drawing.Point(411, 12);
            this.btnSortByDueDate.Name = "btnSortByDueDate";
            this.btnSortByDueDate.Size = new System.Drawing.Size(100, 23);
            this.btnSortByDueDate.TabIndex = 4;
            this.btnSortByDueDate.Text = "Sort by Due Date";
            this.btnSortByDueDate.UseVisualStyleBackColor = true;
            this.btnSortByDueDate.Click += new System.EventHandler(this.btnSortByDueDate_Click);
            // 
            // lstTasks
            // 
            this.lstTasks.FormattingEnabled = true;
            this.lstTasks.Location = new System.Drawing.Point(12, 41);
            this.lstTasks.Name = "lstTasks";
            this.lstTasks.Size = new System.Drawing.Size(499, 290);
            this.lstTasks.TabIndex = 5;
            this.lstTasks.SelectedIndexChanged += new System.EventHandler(this.lstTasks_SelectedIndexChanged);
            // 
            // monthCalendar
            // 
            this.monthCalendar.Location = new System.Drawing.Point(530, 41);
            this.monthCalendar.Name = "monthCalendar";
            this.monthCalendar.TabIndex = 6;
            this.monthCalendar.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar_DateSelected);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 343);
            this.Controls.Add(this.monthCalendar);
            this.Controls.Add(this.lstTasks);
            this.Controls.Add(this.btnSortByDueDate);
            this.Controls.Add(this.btnSortByName);
            this.Controls.Add(this.btnRemoveTask);
            this.Controls.Add(this.btnMarkComplete);
            this.Controls.Add(this.btnAddTask);
            this.Name = "Form1";
            this.Text = "ToDo List";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }
    }
}


