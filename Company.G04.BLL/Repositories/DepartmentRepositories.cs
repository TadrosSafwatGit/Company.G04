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
    public class DepartmentRepositories :GenericRepository<Department> ,IDepartmentRepositories
    {


        public DepartmentRepositories(CompanyDbContext context) :base(context)
        {
            
        }

        // vid num 9

    }
}
