﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace Company.G04.DAl.Models
{
    public class Department :BaseEntity
    {

        public string Code { get; set; }

        public string Name { get; set; }

        public DateTime CreateAt { get; set; }



        public List<Employee> Employees { get; set; }


    }
}
