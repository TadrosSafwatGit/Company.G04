using Company.G04.BLL.Interfaces;
using Company.G04.BLL.Repositories;
using Company.G04.DAl.Models;
using Microsoft.AspNetCore.Mvc;
using MVC._3.PL.Dtos;

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

        [HttpGet]// GET:/Departmnet/index
        public IActionResult Create() 
        {
            

            
            return View();


        }

        [HttpPost]// GET:/Departmnet/index
        public IActionResult Create(CreateDepartmentDto model)
        {

            if (ModelState.IsValid) //server side validations 
            {

                var department = new Department() {
                
                Code=model.Code,
                Name=model.Name,
                CreateAt=model.CreateAt
                };
               var count= _departmentRepository.Add(department);
                if (count > 0) 
                { 
                return RedirectToAction(nameof(Index));
                
                }

            
            }

            return View(model);


        }


        //17.4 min last vid to be continuse 


    }



}
