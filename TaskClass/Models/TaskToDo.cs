using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization; // Untuk kontrol JSON serialization

namespace TaskClass.Models
{
    public partial class TaskToDo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [JsonPropertyName("task_name")] // JSON key saat dikirim/diterima adalah "task_name"
        public string NameTask { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("due_date")]
        public DateTime? DueDate { get; set; }

        [JsonPropertyName("category")]
        public string Category { get; set; }

        [JsonPropertyName("is_complete")]
        public bool IsComplete { get; set; }

        public TaskToDo(int id, string nameTask, string? description, DateTime? dueDate, string category)
        {
            Id = id;
            NameTask = nameTask;
            Description = description;
            DueDate = dueDate;
            Category = category;
            IsComplete = false;
        }

        public TaskToDo() { }

        public override string ToString()
        {
            return $"{NameTask} - {Description} - Due: {DueDate?.ToShortDateString() ?? "No due date"} - Category: {Category} - {IsComplete}";
        }
    }
}
