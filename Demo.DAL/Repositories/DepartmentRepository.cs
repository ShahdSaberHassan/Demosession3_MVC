using Demo.DAL.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Repositories
{
    public class DepartmentRepository(ApplicationDbContext context) : IDepartmentRepository
    //high level model
    {
        private readonly ApplicationDbContext _context = context;


        //ApplicationDbContext context= new ApplicationDbContext(); //low level model

        //public DepartmentRepository(ApplicationDbContext context)
        //{
        //_context = context;

        //    //ask clr to inject object from ApplicationDbContext
        //}
        public Department? GetById(int id)
        {
            var department = _context.Departments.Find(id);
            return department;
        }

        //public DepartmentRepository() 
        //{
        //ApplicationDbContext context = new ApplicationDbContext();
        //}


        //Get  all department
        public IEnumerable<Department> GetAll(bool withTracking = false)
        {
            if (withTracking) return _context.Departments.ToList();
            else return _context.Departments.AsNoTracking().ToList();
        }


        //Add department
        public int Add(Department department)
        {
            _context.Departments.Add(department);
            return _context.SaveChanges();

        }

        //update department
        public int Update(Department department)
        {
            _context.Departments.Update(department);
            return _context.SaveChanges();
        }

        //delete department

        public int Delete(Department department)
        {

            _context.Departments.Remove(department);
            return _context.SaveChanges();
        }
    }
}
