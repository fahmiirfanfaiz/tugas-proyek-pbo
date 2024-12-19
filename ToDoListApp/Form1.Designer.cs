namespace ToDoListApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

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
            Button Edit;
            lstTasks = new ListBox();
            btnAddTask = new Button();
            btnMarkComplete = new Button();
            btnRemoveTask = new Button();
            monthCalendar1 = new MonthCalendar();
            Edit = new Button();
            SuspendLayout();
            // 
            // Edit
            // 
            Edit.Location = new Point(263, 518);
            Edit.Margin = new Padding(2);
            Edit.Name = "Edit";
            Edit.Size = new Size(112, 44);
            Edit.TabIndex = 5;
            Edit.Text = "Edit";
            Edit.UseVisualStyleBackColor = true;
            Edit.Click += Edit_Click;
            // 
            // lstTasks
            // 
            lstTasks.FormattingEnabled = true;
            lstTasks.ItemHeight = 25;
            lstTasks.Items.AddRange(new object[] { "List Task" });
            lstTasks.Location = new Point(20, 22);
            lstTasks.Margin = new Padding(5, 6, 5, 6);
            lstTasks.Name = "lstTasks";
            lstTasks.Size = new Size(598, 429);
            lstTasks.TabIndex = 0;
            lstTasks.SelectedIndexChanged += lstTasks_SelectedIndexChanged;
            // 
            // btnAddTask
            // 
            btnAddTask.Location = new Point(495, 464);
            btnAddTask.Margin = new Padding(5, 6, 5, 6);
            btnAddTask.Name = "btnAddTask";
            btnAddTask.Size = new Size(125, 44);
            btnAddTask.TabIndex = 2;
            btnAddTask.Text = "Add Task";
            btnAddTask.UseVisualStyleBackColor = true;
            btnAddTask.Click += btnAddTask_Click;
            // 
            // btnMarkComplete
            // 
            btnMarkComplete.Location = new Point(20, 518);
            btnMarkComplete.Margin = new Padding(5, 6, 5, 6);
            btnMarkComplete.Name = "btnMarkComplete";
            btnMarkComplete.Size = new Size(236, 44);
            btnMarkComplete.TabIndex = 3;
            btnMarkComplete.Text = "Mark Selected as Complete";
            btnMarkComplete.UseVisualStyleBackColor = true;
            btnMarkComplete.Click += btnMarkComplete_Click;
            // 
            // btnRemoveTask
            // 
            btnRemoveTask.Location = new Point(382, 518);
            btnRemoveTask.Margin = new Padding(5, 6, 5, 6);
            btnRemoveTask.Name = "btnRemoveTask";
            btnRemoveTask.Size = new Size(238, 44);
            btnRemoveTask.TabIndex = 4;
            btnRemoveTask.Text = "Remove Selected Task";
            btnRemoveTask.UseVisualStyleBackColor = true;
            btnRemoveTask.Click += btnRemoveTask_Click;
            // 
            // monthCalendar1
            // 
            monthCalendar1.Location = new Point(632, 22);
            monthCalendar1.Name = "monthCalendar1";
            monthCalendar1.TabIndex = 6;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(956, 579);
            Controls.Add(monthCalendar1);
            Controls.Add(Edit);
            Controls.Add(btnRemoveTask);
            Controls.Add(btnMarkComplete);
            Controls.Add(btnAddTask);
            Controls.Add(lstTasks);
            Margin = new Padding(5, 6, 5, 6);
            Name = "Form1";
            Text = "To-Do List";
            ResumeLayout(false);
        }

        private System.Windows.Forms.ListBox lstTasks;
        private System.Windows.Forms.Button btnAddTask;
        private System.Windows.Forms.Button btnMarkComplete;
        private System.Windows.Forms.Button btnRemoveTask;
        private Button Edit;
        private MonthCalendar monthCalendar1;
    }
}

