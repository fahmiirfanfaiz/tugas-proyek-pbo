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
            btnAddTask = new Button();
            btnMarkComplete = new Button();
            btnRemoveTask = new Button();
            btnSortByName = new Button();
            btnSortByDueDate = new Button();
            lstTasks = new ListBox();
            monthCalendar = new MonthCalendar();
            SuspendLayout();
            // 
            // btnAddTask
            // 
            btnAddTask.Location = new Point(16, 18);
            btnAddTask.Margin = new Padding(4, 5, 4, 5);
            btnAddTask.Name = "btnAddTask";
            btnAddTask.Size = new Size(100, 35);
            btnAddTask.TabIndex = 0;
            btnAddTask.Text = "Add Task";
            btnAddTask.UseVisualStyleBackColor = true;
            btnAddTask.Click += btnAddTask_Click;
            // 
            // btnMarkComplete
            // 
            btnMarkComplete.Location = new Point(124, 18);
            btnMarkComplete.Margin = new Padding(4, 5, 4, 5);
            btnMarkComplete.Name = "btnMarkComplete";
            btnMarkComplete.Size = new Size(133, 35);
            btnMarkComplete.TabIndex = 1;
            btnMarkComplete.Text = "Mark Complete";
            btnMarkComplete.UseVisualStyleBackColor = true;
            btnMarkComplete.Click += btnMarkComplete_Click;
            // 
            // btnRemoveTask
            // 
            btnRemoveTask.Location = new Point(265, 18);
            btnRemoveTask.Margin = new Padding(4, 5, 4, 5);
            btnRemoveTask.Name = "btnRemoveTask";
            btnRemoveTask.Size = new Size(133, 35);
            btnRemoveTask.TabIndex = 2;
            btnRemoveTask.Text = "Remove Task";
            btnRemoveTask.UseVisualStyleBackColor = true;
            btnRemoveTask.Click += btnRemoveTask_Click;
            // 
            // btnSortByName
            // 
            btnSortByName.Location = new Point(407, 18);
            btnSortByName.Margin = new Padding(4, 5, 4, 5);
            btnSortByName.Name = "btnSortByName";
            btnSortByName.Size = new Size(133, 35);
            btnSortByName.TabIndex = 3;
            btnSortByName.Text = "Sort by Name";
            btnSortByName.UseVisualStyleBackColor = true;
            btnSortByName.Click += btnSortByName_Click;
            // 
            // btnSortByDueDate
            // 
            btnSortByDueDate.Location = new Point(548, 18);
            btnSortByDueDate.Margin = new Padding(4, 5, 4, 5);
            btnSortByDueDate.Name = "btnSortByDueDate";
            btnSortByDueDate.Size = new Size(133, 35);
            btnSortByDueDate.TabIndex = 4;
            btnSortByDueDate.Text = "Sort by Due Date";
            btnSortByDueDate.UseVisualStyleBackColor = true;
            btnSortByDueDate.Click += btnSortByDueDate_Click;
            // 
            // lstTasks
            // 
            lstTasks.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lstTasks.FormattingEnabled = true;
            lstTasks.Location = new Point(16, 63);
            lstTasks.Margin = new Padding(4, 5, 4, 5);
            lstTasks.Name = "lstTasks";
            lstTasks.Size = new Size(664, 444);
            lstTasks.TabIndex = 5;
            lstTasks.SelectedIndexChanged += lstTasks_SelectedIndexChanged;
            // 
            // monthCalendar
            // 
            monthCalendar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            monthCalendar.Location = new Point(688, 63);
            monthCalendar.Margin = new Padding(12, 14, 12, 14);
            monthCalendar.Name = "monthCalendar";
            monthCalendar.TabIndex = 6;
            monthCalendar.DateChanged += monthCalendar_DateChanged;
            monthCalendar.DateSelected += monthCalendar_DateSelected;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(912, 528);
            Controls.Add(monthCalendar);
            Controls.Add(lstTasks);
            Controls.Add(btnSortByDueDate);
            Controls.Add(btnSortByName);
            Controls.Add(btnRemoveTask);
            Controls.Add(btnMarkComplete);
            Controls.Add(btnAddTask);
            Margin = new Padding(4, 5, 4, 5);
            MinimumSize = new Size(800, 400); // Set minimum size
            Name = "Form1";
            Text = "To Do List";
            Load += Form1_Load;
            ResumeLayout(false);
        }
    }
}
