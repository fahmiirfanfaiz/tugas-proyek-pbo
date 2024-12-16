namespace TaskClass
{
    public class TaskToDo
    {
        public int Id { get; }
        public string Description { get; }
        public bool IsComplete { get; set; }

        public TaskToDo(int id, string description)
        {
            Id = id;
            Description = description;
            IsComplete = false;
        }

        public override string ToString()
        {
            return $"{Id}: {Description} - {(IsComplete ? "Complete" : "Incomplete")}";
        }
    }
}

