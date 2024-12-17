namespace TaskClass
{
    public class TaskToDo
    {
        public int Id { get; }

        public string NameTask { get; }
        public string Description { get; }
        public bool IsComplete { get; set; }
        public DateTime DueDate { get; set; }
        public string Category { get; set; }

        public TaskToDo(int id, string nameTask, string description, DateTime dueDate, string category)
        {
            Id = id;
            NameTask = nameTask;
            Description = description;
            IsComplete = false;
            DueDate = dueDate;
            Category = category;
        }

        public override string ToString()
        {
            return $"{Id}: {NameTask} - {(IsComplete ? "Complete" : "Incomplete")}";
        }
    }
}

