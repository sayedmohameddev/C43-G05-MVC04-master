using IKEA.DAL.Models.Departments;
using IKEA.DAL.presistance.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.DAL.presistance.Repository.Departments
{
    public class DepartmentRepositry : IDepartmentRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public DepartmentRepositry(ApplicationDbContext dbContext )
        {
           // Ask Clr For Object From ApplicationContext Implicity

            _dbContext = dbContext;
        }



        public IEnumerable<Department> GetAll(bool withAsTracking = true)
        {
            if (withAsTracking)
            {
                _dbContext.Deaprtments.AsNoTracking().ToList();
            }
            return _dbContext.Deaprtments.ToList();

        }

        public Department? GetbyID(int id)
        {
           // var Department = _dbContext.Deaprtments.local.FirstOrDefault(D => D.Id == id);
            var Department = _dbContext.Deaprtments.Find(id);
            return Department;

        }
        public int Add(Department entity)
        {
            _dbContext.Deaprtments.Add(entity);
            //Add local
            return _dbContext.SaveChanges();
        }
        public int Update(Department entity)
        {
           _dbContext.Deaprtments.Update(entity);
            return _dbContext.SaveChanges();


        }
        public int Delete(Department entity)
        {
            _dbContext.Deaprtments.Remove(entity);
            return _dbContext.SaveChanges();
        }

        public IQueryable<Department> GetAllAsQueryable()
        {
            return _dbContext.Deaprtments;
        }
    }
}
