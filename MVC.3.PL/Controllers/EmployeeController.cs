using Company.G04.BLL.Interfaces;
using Company.G04.DAl.Models;
using Microsoft.AspNetCore.Mvc;
using MVC._3.PL.Dtos;

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



        [HttpGet]
        public IActionResult Create()
        {



            return View();


        }

        [HttpPost]
        public IActionResult Create(CreateEmployeeDto model)
        {

            if (ModelState.IsValid) 
            {

                var employee = new Employee()
                {
                    Name=model.Name,
                    Age=model.Age,
                    Salary=model.Salary,
                    Address=model.Address,
                    IsActive=model.IsActive,
                    IsDeleted=model.IsDeleted,
                    CreateAt=model.CreateAt,
                    Email=model.Email,
                    HiringDate=model.HiringDate,
                    Phone=model.Phone
                   
                };
                var count = _employeeRepository.Add(employee);
                if (count > 0)
                {
                    return RedirectToAction(nameof(Index));

                }


            }

            return View(model);


        }



        [HttpGet]
        public IActionResult Details(int? id, string viewName = "Details") 
        {
            if (id is null) return BadRequest("Invaild Id");
            var employee = _employeeRepository.Get(id.Value);
            if (employee is null) return NotFound(new { StatusCode = 404, Message = $"employee  with id {id} is Not Found !" });
            return View(viewName, employee);

        }


        [HttpGet]
        public IActionResult Edit(int? id)
        {
       

            return Details(id, "Edit");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute] int id, Employee model)
        {
            if (ModelState.IsValid) 
            {


                if (id != model.Id) return BadRequest();
                var count = _employeeRepository.Update(model);
                if (count > 0) 
                {

                    return RedirectToAction(nameof(Index));
                
                }
            
            }
            return View(model);

        }



        ////////////////////////////////////////////////////






        public IActionResult Delete(int? id)
        {
           

            return Details(id, "Delete");

        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete([FromRoute] int id, Employee model)
        {
            if (ModelState.IsValid)
            {


                if (id != model.Id) return BadRequest();
                var count = _employeeRepository.Delete(model);
                if (count > 0)
                {

                    return RedirectToAction(nameof(Index));

                }


            }

            return View(model);

        }




        //min16:10



    }
}
