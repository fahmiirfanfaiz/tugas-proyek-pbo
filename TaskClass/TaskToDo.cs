using System.ComponentModel.DataAnnotations;

namespace TaskClass
{
    public class TaskToDo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string NameTask { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public string Category { get; set; }
        public bool IsComplete { get; set; }

        // Constructor with parameters
        public TaskToDo(int id, string nameTask, string description, DateTime dueDate, string category)
        {
            Id = id;
            NameTask = nameTask;
            Description = description;
            DueDate = dueDate;
            Category = category;
            IsComplete = false;
        }

        // Default constructor (needed for EF)
        public TaskToDo()
        {
        }

        public override string ToString()
        {
            return $"{Id}: {NameTask} - {(IsComplete ? "Complete" : "Incomplete")}";
        }
    }
}
