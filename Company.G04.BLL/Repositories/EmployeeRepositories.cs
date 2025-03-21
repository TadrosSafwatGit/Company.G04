using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.G04.BLL.Interfaces;
using Company.G04.DAl.Data.Context;
using Company.G04.DAl.Models;

namespace Company.G04.BLL.Repositories
{
    public class EmployeeRepositories : IEmployeeRepositories
    {
        private readonly CompanyDbContext _context;

        public EmployeeRepositories(CompanyDbContext context)
        {
           _context = context;
        }

        public IEnumerable<Employee> GetAll()
        {
            return _context.employees.ToList();
        }

        public Employee? Get(int id)
        {
            return _context.employees.Find(id);
        }

        public int Update(Employee model)
        {
             _context.employees.Update(model);
            return _context.SaveChanges();
        }


        public int Add(Employee model)
        {
            _context.employees.Add(model);
            return _context.SaveChanges();
        }

        public int Delete(Employee model)
        {
            _context.employees.Remove(model);
            return _context.SaveChanges();
        }

    
    

     
    }
}
