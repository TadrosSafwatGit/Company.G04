using Company.G04.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MVC._3.PL.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepositories _employeeRepository;

        public EmployeeController(IEmployeeRepositories employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]

        public IActionResult Index()
        {
            var employee = _employeeRepository.GetAll();



            return View(employee);
        }



    }
}
