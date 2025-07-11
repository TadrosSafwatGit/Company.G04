﻿using System.ComponentModel.DataAnnotations;
using Company.G04.BLL.Interfaces;
using Company.G04.BLL.Repositories;
using Company.G04.DAl.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using MVC._3.PL.Dtos;

namespace MVC._3.PL.Controllers
{
    //[Authorize]
    public class DepartmentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        //private readonly IDepartmentRepositories _departmentRepository;
        public DepartmentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]// GET:/Departmnet/index
        public IActionResult Index()
        {
            var department = _unitOfWork.DepartmentRepository.GetAll();



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

                var department = new Department()
                {

                    Code = model.Code,
                    Name = model.Name,
                    CreateAt = model.CreateAt
                };
                 _unitOfWork.DepartmentRepository.Add(department);
                var count = _unitOfWork.Complete();
                if (count > 0)
                {
                    return RedirectToAction(nameof(Index));

                }


            }

            return View(model);


        }
        [HttpGet]
        public IActionResult Details(int? id,string viewName="Details") // refactor
        {
            if (id is null) return BadRequest("Invaild Id");
            var department = _unitOfWork.DepartmentRepository.Get(id.Value);
            if (department is null) return NotFound(new { StatusCode = 404, Message = $"Department  with id {id} is Not Found !" });
            return View(viewName,department);

        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            //if (id is null) return BadRequest("Invaild Id");
            //var department = _departmentRepository.Get(id.Value);
            //if (department is null) return NotFound(new { StatusCode = 404, Message = $"Department  with id {id} is Not Found !" });

            return Details(id,"Edit");

        }
        //[HttpPost]
        //public IActionResult Edit( [FromRoute]int id,Department department)
        //{
        //    if (ModelState.IsValid) 
        //    {
        //        if (id == department.Id)
        //        {
        //            var count = _departmentRepository.Update(department);

        //            if (count > 0)
        //            {
        //                return RedirectToAction(nameof(Index));
        //            }
        //        }


        //    }

        //    return View(department);

        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute] int id, UpdateDepartmentDto model)
        {
            if (ModelState.IsValid)
            {

                var department = new Department()
                {

                    Id = id,
                    Name = model.Name,
                    Code = model.Code,
                    CreateAt = model.CreateAt

                };
                _unitOfWork.DepartmentRepository.Update(department);
                var count = _unitOfWork.Complete();

                if (count > 0)
                {
                    return RedirectToAction(nameof(Index));
                }



            }

            return View(model);

        }


        public IActionResult Delete(int? id)
        {
            //if (id is null) return BadRequest("Invaild Id");
            //var department = _departmentRepository.Get(id.Value);
            //if (department is null) return NotFound(new { StatusCode = 404, Message = $"Department  with id {id} is Not Found !" });

            return Details(id, "Delete");







        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete([FromRoute] int id, UpdateDepartmentDto model)
        {
            if (ModelState.IsValid)
            {

                var department = new Department()
                {

                    Id = id,
                    Name = model.Name,
                    Code = model.Code,
                    CreateAt = model.CreateAt

                };
                _unitOfWork.DepartmentRepository.Delete(department);
                var count = _unitOfWork.Complete();

                if (count > 0)
                {
                    return RedirectToAction(nameof(Index));
                }



            }

            return View(model);

        }
        ///12312

    }//jjj
}
