using System;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TaskClass;
using TaskClass.Models;
using TaskSorterClass;

namespace ToDoListApp
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // Konfigurasi Dependency Injection
            var serviceProvider = ConfigureServices();

            // Buat instance Form1 dari ServiceProvider
            using (var scope = serviceProvider.CreateScope())
            {
                var form1 = scope.ServiceProvider.GetRequiredService<Form1>();
                Application.Run(form1);
            }
        }

        private static ServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            // Konfigurasi DbContext
            services.AddDbContext<ToDoListDbContext>(options =>
                options.UseSqlServer("Data Source=LAPTOP-2D8G3I8L\\SQLEXPRESS;Initial Catalog=ToDoListDB;Integrated Security=True;Pooling=False;Encrypt=False;Trust Server Certificate=True"));

            // Tambahkan HttpClient untuk TaskManager
            services.AddHttpClient<TaskManager>(client =>
            {
                client.BaseAddress = new Uri("http://localhost:5000/api/");
            });

            // Tambahkan layanan lainnya
            services.AddScoped<TaskSorter>();
            services.AddScoped<TaskManager>();

            // Tambahkan Form1
            services.AddScoped<Form1>();

            return services.BuildServiceProvider();
        }
    }
}
