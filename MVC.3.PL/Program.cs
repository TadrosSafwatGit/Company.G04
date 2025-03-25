using Company.G04.BLL.Interfaces;
using Company.G04.BLL.Repositories;
using Company.G04.DAl.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace MVC._3.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();// regeseter bulit in   MVC Service 
            builder.Services.AddScoped<IDepartmentRepositories, DepartmentRepositories>();// allow dependances ingections for DepartmentReposatres
            builder.Services.AddScoped<IEmployeeRepositories, EmployeeRepositories>();
            builder.Services.AddDbContext<CompanyDbContext>(options => 
            {

                options.UseSqlServer(builder.Configuration.GetConnectionString("DefualtConnection"));
            
            }
            );//  allow dependances ingections for CompanyDbContext



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();


            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
