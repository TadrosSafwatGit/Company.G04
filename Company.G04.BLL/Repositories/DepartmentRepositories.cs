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
    public class DepartmentRepositories : IDepartmentRepositories
    {
        private readonly CompanyDbContext _context;

        public DepartmentRepositories()
        {
            _context = new CompanyDbContext();
        }

        public IEnumerable<Department> GetAll()
        {

            return _context.departments.ToList(); 
        }

        public Department? Get(int id)
        {

            return _context.departments.Find(id);
        }


        public int Add(Department model)
        {
            _context.departments.Add(model);
             return _context.SaveChanges();  
        }

        public int Update(Department model)
        {
            _context.departments.Update(model);
            return _context.SaveChanges();
        }

        public int Delete(Department model)
        {
            _context.departments.Remove(model);
            return _context.SaveChanges();
        }

      

      

       
    }
}
