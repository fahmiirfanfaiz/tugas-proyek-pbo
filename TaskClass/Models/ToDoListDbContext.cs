using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TaskClass.Models;

public partial class ToDoListDbContext : DbContext
{
    public ToDoListDbContext()
    {
    }

    public ToDoListDbContext(DbContextOptions<ToDoListDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TaskToDo> TaskToDos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-2D8G3I8L\\SQLEXPRESS;Initial Catalog=ToDoListDB;Integrated Security=True;Pooling=False;Encrypt=False;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TaskToDo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TaskToDo__3214EC077FBA3CE3");

            entity.ToTable("TaskToDo");

            entity.Property(e => e.Category).HasMaxLength(255);
            entity.Property(e => e.DueDate).HasColumnType("datetime");
            entity.Property(e => e.NameTask).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
