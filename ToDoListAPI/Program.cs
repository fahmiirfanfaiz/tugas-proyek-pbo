using Microsoft.EntityFrameworkCore;
using TaskClass;
using TaskClass.Models;

var builder = WebApplication.CreateBuilder(args);

// Tambahkan koneksi DbContext
builder.Services.AddDbContext<ToDoListDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();

var app = builder.Build();

app.UseAuthorization();
app.MapControllers();

app.Run();
