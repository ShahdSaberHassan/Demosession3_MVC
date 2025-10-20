using Demo.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.DTOs
{
  public class DepartmentDetailsDto
    {

        //public DepartmentDetailsDto (Department dept) 
        //{
        //    //set all value of current object : this--> from department

        //    Id = dept.Id;
        //    Name = dept.Name;
        //    Code = dept.Code;
        //    CreatedBy = dept.CreatedBy;
        //    LastModifiedBy = dept.LastModifiedBy;
        //    IsDeleted = dept.IsDeleted;
        //    LastModifiedOn = DateOnly.FromDateTime(dept.LastModifiedOn);
        //}
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string Code { get; internal set; }
        public DateOnly DateOfCreation { get; set; }

        public int CreatedBy { get; set; }
        public int LastModifiedBy { get; set; }
        public DateOnly LastModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
    }

   
}
