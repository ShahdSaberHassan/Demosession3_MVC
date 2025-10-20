using Demo.BLL.DTOs;
using Demo.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Factories
{
    static class DepartmentFactory
    {
        public static DepartmentDTOs ToDepartment(this Department department)
        {
            return new DepartmentDTOs()
            {
                DeptId = department.Id,
                Name = department.Name,
                Code = department.Code,
                Description = department.Description,
                DateOfCreation = DateOnly.FromDateTime(department.CreatedOn),
            };
        }

        public static DepartmentDetailsDto ToDepartmentDetailsDto(this Department dept)
        {
            return new DepartmentDetailsDto()
            {
                Id = dept.Id,
                Name = dept.Name,
                Code = dept.Code,
                CreatedBy = dept.CreatedBy,
                LastModifiedBy = dept.LastModifiedBy,
                IsDeleted = dept.IsDeleted,
                LastModifiedOn = DateOnly.FromDateTime(dept.LastModifiedOn),
            };
        }


        public static Department ToEntity(this CreatedDepartmentDto dto)
        {
            return new Department()
            {
                Name = dto.Name,
                Code = dto.Code,
                Description = dto.Description,
                CreatedOn = dto.DatOfCreation.ToDateTime(new TimeOnly())
            };

        }
        public static Department ToEntity(this UbdateDepartmentDto dto)
        {
            return new Department()
            {
                Id = dto.Id,
                Name = dto.Name,
                Code = dto.Code,
                Description = dto.Description,
                CreatedOn = dto.DatOfCreation.ToDateTime(new TimeOnly())
            };

        }
    }
}
