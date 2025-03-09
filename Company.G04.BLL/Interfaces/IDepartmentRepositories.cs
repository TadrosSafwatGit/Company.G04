﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.G04.DAl.Models;

namespace Company.G04.BLL.Interfaces
{
    public interface IDepartmentRepositories
    {

        IEnumerable<Department> GetAll();
      Department?  Get(int id);

        int Add(Department model);
        int Update(Department model);
        int Delete (Department model);

    }
}
