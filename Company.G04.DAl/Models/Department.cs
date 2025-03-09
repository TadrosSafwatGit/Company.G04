using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace Company.G04.DAl.Models
{
    internal class Department
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public DateTime CreateAt { get; set; }

    }
}
