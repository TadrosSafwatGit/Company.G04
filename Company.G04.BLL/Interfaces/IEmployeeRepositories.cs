using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.G04.DAl.Models;

namespace Company.G04.BLL.Interfaces
{
    public interface IEmployeeRepositories : IGenericRepository<Employee>
    {
        //IEnumerable<Employee> GetAll();
        //Employee? Get(int id);

        //int Add(Employee model);
        //int Update(Employee model);
        //int Delete(Employee model);


       List <Employee> GetByName(string name);
        
    }
}
