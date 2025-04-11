using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.G04.BLL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
         IDepartmentRepositories DepartmentRepository { get;  }
        IEmployeeRepositories EmployeeRepository { get;  }

        int Complete();

    }
}
