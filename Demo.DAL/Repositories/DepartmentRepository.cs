using Demo.DAL.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Repositories
{
    internal class DepartmentRepository   //high level model
    {
        private readonly ApplicationDbContext _context;


        //ApplicationDbContext context= new ApplicationDbContext(); //low level model

        public DepartmentRepository(ApplicationDbContext context)
        {
        _context = context;

            //ask clr to inject object from ApplicationDbContext
        }
        public Department? GetById(int id)
        {
            var department = _context.Departments.Find(id);
            return department;
        }

        //public DepartmentRepository() 
        //{
        //ApplicationDbContext context = new ApplicationDbContext();
        //}
    }
}
