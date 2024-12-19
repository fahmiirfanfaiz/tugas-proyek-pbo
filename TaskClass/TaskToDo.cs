using System;
using System.ComponentModel.DataAnnotations;

namespace TaskClass
{
    public class TaskToDo
    {
        // Primary Key
        [Key]
        public int Id { get; set; }

        // Nama task harus diisi
        [Required]
        public string NameTask { get; set; }

        // Deskripsi task (opsional)
        public string? Description { get; set; }

        // Tanggal jatuh tempo
        public DateTime? DueDate { get; set; }

        // Kategori task
        public string Category { get; set; }

        // Status apakah task sudah selesai
        public bool IsComplete { get; set; }

        // Constructor dengan parameter untuk mempermudah inisialisasi
        public TaskToDo(int id, string nameTask, string description, DateTime dueDate, string category)
        {
            Id = id;
            NameTask = nameTask;
            Description = description;
            DueDate = dueDate;
            Category = category;
            IsComplete = false; // Default status task adalah belum selesai
        }

        // Constructor default (dibutuhkan oleh Entity Framework)
        public TaskToDo()
        {
        }

        // Override ToString untuk tampilan yang lebih jelas saat debugging
        public override string ToString()
        {
            return $"{Id}: {NameTask} - {(IsComplete ? "Complete" : "Incomplete")}";
        }
    }
}
