using IKEA.DAL.Models.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.DAL.presistance.Repository.Departments
{
    public interface IDepartmentRepository
    {
        IEnumerable<Department> GetAll(bool withAsTracking = true);
        IQueryable<Department> GetAllAsQueryable();    
        Department? GetbyID(int id);
        int Add(Department entity);
        int Update(Department entity);
        int Delete(Department entity);  

    }
}
