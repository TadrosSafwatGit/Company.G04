using AutoMapper;
using Company.G04.BLL.Interfaces;
using Company.G04.DAl.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC._3.PL.Dtos;
using MVC._3.PL.Helpers;

namespace MVC._3.PL.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        //private readonly IEmployeeRepositories _employeeRepository;
        //private readonly IDepartmentRepositories _departmentRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeController(
            //IEmployeeRepositories employeeRepository,
            //IDepartmentRepositories departmentRepository,
            IMapper mapper
            ,
            IUnitOfWork unitOfWork
            )
        {
          //  _employeeRepository = employeeRepository;
          //_departmentRepository = departmentRepository;
            _mapper = mapper;
             _unitOfWork = unitOfWork;
        }

        [HttpGet]

        public IActionResult Index(string? searchIput)
        {

            IEnumerable<Employee> employee;

            if (string.IsNullOrEmpty(searchIput))
            {
                 employee = _unitOfWork.EmployeeRepository.GetAll();

            }
            else 
            {
                 employee = _unitOfWork.EmployeeRepository.GetByName(searchIput);




            }

         


            return View(employee);
        }



        [HttpGet]
        public IActionResult Create()
        {

           var departments= _unitOfWork.DepartmentRepository.GetAll();
            ViewData["departments"] = departments;

            return View();


        }

        [HttpPost]
        public IActionResult Create(CreateEmployeeDto model)
        {

            if (ModelState.IsValid) 
            {

                if (model.Image is not null)
                {
                    model.ImageName = DocumentSetting.UploadFile(model.Image, "images");

                }


                var employee = _mapper.Map<Employee>(model);
                _unitOfWork.EmployeeRepository.Add(employee);
              var count=   _unitOfWork.Complete();
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
            var employee = _unitOfWork.EmployeeRepository.Get(id.Value);
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
        public IActionResult Edit([FromRoute] int id, Employee model, IFormFile? image)
        {
            if (!ModelState.IsValid)
                return View(model);

            var employeeInDb = _unitOfWork.EmployeeRepository.Get(id);
            if (employeeInDb is null) return NotFound();
            if (id != model.Id) return BadRequest();

            // Handle image
            if (image is not null)
            {
                if (!string.IsNullOrEmpty(employeeInDb.ImageName))
                {
                    DocumentSetting.DeleteFile("images", employeeInDb.ImageName);
                }

                employeeInDb.ImageName = DocumentSetting.UploadFile(image, "images");
            }

            // Map other fields
            _mapper.Map(model, employeeInDb);

            var count = _unitOfWork.Complete();
            if (count > 0)
                return RedirectToAction(nameof(Index));

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
                 _unitOfWork.EmployeeRepository.Delete(model);
                var count = _unitOfWork.Complete();
                if (count > 0)
                {

                    return RedirectToAction(nameof(Index));

                }


            }

            return View(model);

        }




        //min16:10

        ////vid 5-min 1



    }
}
