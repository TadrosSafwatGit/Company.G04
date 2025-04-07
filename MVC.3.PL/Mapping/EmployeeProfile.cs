using AutoMapper;
using Company.G04.DAl.Models;
using MVC._3.PL.Dtos;

namespace MVC._3.PL.Mapping
{
    public class EmployeeProfile :Profile
    {
        public EmployeeProfile()
        {
            CreateMap<CreateEmployeeDto, Employee>();
        }


    }
}
