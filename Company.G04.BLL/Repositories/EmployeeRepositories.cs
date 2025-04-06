using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.G04.BLL.Interfaces;
using Company.G04.DAl.Data.Context;
using Company.G04.DAl.Models;
using Microsoft.EntityFrameworkCore;

namespace Company.G04.BLL.Repositories
{
    public class EmployeeRepositories : GenericRepository<Employee>, IEmployeeRepositories
    {
        private readonly CompanyDbContext _context;

        public EmployeeRepositories(CompanyDbContext context) :base(context) // ASk clr to creat object from company Dbcontext
        {
            
            _context = context;
        }

        public int Delete(object model)
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetByName(string name)
        {
            return _context.Employees.Include(E=>E.Department).Where(E => E.Name.ToLower().Contains(name.ToLower())).ToList();
        }
    }
}
