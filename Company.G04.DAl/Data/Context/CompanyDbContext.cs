using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Company.G04.DAl.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Company.G04.DAl.Data.Context
{
    //CLR 
    public class CompanyDbContext : IdentityDbContext<AppUser>
    {
        public object employees;

        public CompanyDbContext(DbContextOptions<CompanyDbContext>options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("server= .;Database=CompanyG04;Trusted_Connection=True;TrustServerCertifcate=True");
        //}

        public DbSet<Department> departments { get; set; }
        public DbSet<Employee> Employees { get; set; }


        //public DbSet<IdentityUser> Users { get; set; }

        //public DbSet<IdentityRole> MyProperty { get; set; }


    }
}
