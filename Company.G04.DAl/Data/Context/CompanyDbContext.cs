using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Company.G04.DAl.Models;
using Microsoft.EntityFrameworkCore;

namespace Company.G04.DAl.Data.Context
{
    //CLR 
    public class CompanyDbContext :DbContext 
    {
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
    }
}
