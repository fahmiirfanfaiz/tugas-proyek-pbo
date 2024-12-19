using System;
using System.ComponentModel.DataAnnotations;

namespace TaskClass.Models
{
    public partial class TaskToDo
    {
        [Key]
        public int Id { get; set; }

        // Nama task (wajib diisi)
        [Required]
        public string NameTask { get; set; }

        // Deskripsi task (bisa null)
        public string? Description { get; set; }

        // Tanggal jatuh tempo (bisa null)
        public DateTime? DueDate { get; set; }

        // Kategori task
        public string Category { get; set; }

        // Status apakah task sudah selesai
        public bool IsComplete { get; set; }

        // Constructor dengan parameter untuk mempermudah inisialisasi
        public TaskToDo(int id, string nameTask, string? description, DateTime? dueDate, string category)
        {
            Id = id;
            NameTask = nameTask;
            Description = description;
            DueDate = dueDate;
            Category = category;
            IsComplete = false; // Default status task adalah belum selesai
        }

        // Constructor default (dibutuhkan oleh Entity Framework)
        public TaskToDo() { }

        // Override ToString untuk tampilan yang lebih jelas saat debugging
        public override string ToString()
        {
            return $"{NameTask} - {Description} - Due: {DueDate?.ToShortDateString() ?? "No due date"} - Category: {Category} - {IsComplete}";
        }
    }
}
