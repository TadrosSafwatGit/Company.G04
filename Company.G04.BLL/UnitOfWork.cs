using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.G04.BLL.Interfaces;
using Company.G04.BLL.Repositories;
using Company.G04.DAl.Data.Context;

namespace Company.G04.BLL
{
    public class UnitOfWork : IUnitOfWork

    {
        private readonly CompanyDbContext _context;

        public IDepartmentRepositories DepartmentRepository { get;  } // NULL

        public IEmployeeRepositories EmployeeRepository { get; } //NULL



        public UnitOfWork(CompanyDbContext context)
        {
            _context = context;
            DepartmentRepository = new DepartmentRepositories(_context);
            EmployeeRepository = new EmployeeRepositories(_context);
            
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
           _context.Dispose();
        }
    }
}
