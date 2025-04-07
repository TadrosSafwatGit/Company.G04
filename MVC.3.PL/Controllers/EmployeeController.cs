using AutoMapper;
using Company.G04.BLL.Interfaces;
using Company.G04.DAl.Models;
using Microsoft.AspNetCore.Mvc;
using MVC._3.PL.Dtos;

namespace MVC._3.PL.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepositories _employeeRepository;
        private readonly IDepartmentRepositories _departmentRepository;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeRepositories employeeRepository,
            IDepartmentRepositories departmentRepository,
            IMapper mapper
            )
        {
            _employeeRepository = employeeRepository;
          _departmentRepository = departmentRepository;
            _mapper = mapper;
        }

        [HttpGet]

        public IActionResult Index(string? searchIput)
        {

            IEnumerable<Employee> employee;

            if (string.IsNullOrEmpty(searchIput))
            {
                 employee = _employeeRepository.GetAll();

            }
            else 
            {
                 employee = _employeeRepository.GetByName(searchIput);




            }

            // diCTINARY 3 proprety
            // Viewdata trancfer excetra information from controler to view
            //ViewData["Message"] = "hello from ViewData";



            // ViewBag   trancfer excetra information from controler to view

            //ViewBag.Message = "Hello from ViewBag";

            // TempData


            return View(employee);
        }



        [HttpGet]
        public IActionResult Create()
        {

           var departments=  _departmentRepository.GetAll();
            ViewData["departments"] = departments;

            return View();


        }

        [HttpPost]
        public IActionResult Create(CreateEmployeeDto model)
        {

            if (ModelState.IsValid) 
            {
                //Manual mapper
                //var employee = new Employee()
                //{
                //    Name=model.Name,
                //    Age=model.Age,
                //    Salary=model.Salary,
                //    Address=model.Address,
                //    IsActive=model.IsActive,
                //    IsDeleted=model.IsDeleted,
                //    CreateAt=model.CreateAt,
                //    Email=model.Email,
                //    HiringDate=model.HiringDate,
                //    Phone=model.Phone,




                //};
                var employee= _mapper.Map<Employee>(model);
                var count = _employeeRepository.Add(employee);
                if (count > 0)
                {

                    TempData  ["Message"] = "Employee created ";
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
