namespace TaskClass
{
    public class TaskToDo
    {
        public int Id { get; }
        public string Description { get; }
        public bool IsComplete { get; set; }
        public DateTime DueDate { get; set; }
        public string Category { get; set; }

        public TaskToDo(int id, string description, DateTime dueDate, string category)
        {
            Id = id;
            Description = description;
            IsComplete = false;
            DueDate = dueDate;
            Category = category;
        }

        public override string ToString()
        {
            return $"{Id}: {Description} - {(IsComplete ? "Complete" : "Incomplete")}";
        }
    }
}

