﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.G04.BLL.Interfaces;
using Company.G04.DAl.Data.Context;
using Company.G04.DAl.Models;
using Microsoft.EntityFrameworkCore;

namespace Company.G04.BLL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly CompanyDbContext _context;

        public GenericRepository(CompanyDbContext context)
        {
           _context = context;
        }

        public IEnumerable<T> GetAll()
        { if (typeof(T) == typeof(Employee)) 
            {

               return (IEnumerable<T>)_context.Employees.Include(E=>E.Department).ToList();
            }
            return _context.Set<T>().ToList();
        }




        public T? Get(int id)
        {
            if (typeof(T) == typeof(Employee))
            {
                var employee = _context.Employees
                    .Include(e => e.Department)
                    .FirstOrDefault(e => e.Id == id);

                return employee as T;
            }

            return _context.Set<T>().Find(id);
        }


        //public T? Get(int id)
        //{
        //    if (typeof(T) == typeof(Employee))
        //    {
        //        return (T?)(object)_context.Employees
        //            .Include(E => E.Department)
        //            .FirstOrDefault(e => e.Id == id);
        //    }

        //    return _context.Set<T>().Find(id);
        //}




        public void Add(T model)
        {
           _context.Set<T>().Add(model);
        }
        public void Update(T model)
        {
            _context.Set<T>().Update(model);
        }

        public void Delete(T model)
        {
            _context.Set<T>().Remove(model);
        }

       

       /////////////////

        
    }
}
