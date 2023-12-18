using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using DataLayer.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Vidly
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            string mainConnectionString = builder.Configuration.GetConnectionString("MainConnection") ??
                throw new Exception("Connection string was not read");

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<UniDbContext>(options => options.UseSqlServer(mainConnectionString, b => b.MigrationsAssembly("DataLayer")));
           
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
