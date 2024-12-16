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
            lstTasks = new ListBox();
            txtNewTask = new TextBox();
            btnAddTask = new Button();
            btnMarkComplete = new Button();
            btnRemoveTask = new Button();
            SuspendLayout();
            // 
            // lstTasks
            // 
            lstTasks.FormattingEnabled = true;
            lstTasks.Location = new Point(16, 18);
            lstTasks.Margin = new Padding(4, 5, 4, 5);
            lstTasks.Name = "lstTasks";
            lstTasks.Size = new Size(479, 344);
            lstTasks.TabIndex = 0;
            lstTasks.SelectedIndexChanged += lstTasks_SelectedIndexChanged;
            // 
            // txtNewTask
            // 
            txtNewTask.Location = new Point(16, 374);
            txtNewTask.Margin = new Padding(4, 5, 4, 5);
            txtNewTask.Name = "txtNewTask";
            txtNewTask.Size = new Size(371, 27);
            txtNewTask.TabIndex = 1;
            txtNewTask.TextChanged += txtNewTask_TextChanged;
            // 
            // btnAddTask
            // 
            btnAddTask.Location = new Point(396, 371);
            btnAddTask.Margin = new Padding(4, 5, 4, 5);
            btnAddTask.Name = "btnAddTask";
            btnAddTask.Size = new Size(100, 35);
            btnAddTask.TabIndex = 2;
            btnAddTask.Text = "Add Task";
            btnAddTask.UseVisualStyleBackColor = true;
            btnAddTask.Click += btnAddTask_Click;
            // 
            // btnMarkComplete
            // 
            btnMarkComplete.Location = new Point(16, 414);
            btnMarkComplete.Margin = new Padding(4, 5, 4, 5);
            btnMarkComplete.Name = "btnMarkComplete";
            btnMarkComplete.Size = new Size(236, 35);
            btnMarkComplete.TabIndex = 3;
            btnMarkComplete.Text = "Mark Selected as Complete";
            btnMarkComplete.UseVisualStyleBackColor = true;
            btnMarkComplete.Click += btnMarkComplete_Click;
            // 
            // btnRemoveTask
            // 
            btnRemoveTask.Location = new Point(260, 414);
            btnRemoveTask.Margin = new Padding(4, 5, 4, 5);
            btnRemoveTask.Name = "btnRemoveTask";
            btnRemoveTask.Size = new Size(236, 35);
            btnRemoveTask.TabIndex = 4;
            btnRemoveTask.Text = "Remove Selected Task";
            btnRemoveTask.UseVisualStyleBackColor = true;
            btnRemoveTask.Click += btnRemoveTask_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(512, 463);
            Controls.Add(btnRemoveTask);
            Controls.Add(btnMarkComplete);
            Controls.Add(btnAddTask);
            Controls.Add(txtNewTask);
            Controls.Add(lstTasks);
            Margin = new Padding(4, 5, 4, 5);
            Name = "Form1";
            Text = "To-Do List";
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.ListBox lstTasks;
        private System.Windows.Forms.TextBox txtNewTask;
        private System.Windows.Forms.Button btnAddTask;
        private System.Windows.Forms.Button btnMarkComplete;
        private System.Windows.Forms.Button btnRemoveTask;
    }
}

