using Company.G04.BLL.Interfaces;
using Company.G04.BLL.Repositories;
using Company.G04.DAl.Models;
using Microsoft.AspNetCore.Mvc;

namespace MVC._3.PL.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepositories _departmentRepository;
        public DepartmentController(IDepartmentRepositories departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        [HttpGet]// GET:/Departmnet/index
        public IActionResult Index()
        {
           var department = _departmentRepository.GetAll();



            return View(department);
        }
    }
}
