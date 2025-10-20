using Demo.BLL.DTOs;
using Demo.BLL.Factories;
using Demo.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL
{
    public class DepartmentService(IDepartmentRepository _departmentRepository) : IDepartmentService
    {

        public IEnumerable<DepartmentDTOs> GetAllDepartments()
        {
            var depts = _departmentRepository.GetAll();

            var departmentToReturn = depts.Select(d => new DepartmentDTOs()
            {
                DeptId = d.Id,
                Name = d.Name,
                Code = d.Code,
                Description = d.Description,
                DateOfCreation = DateOnly.FromDateTime(d.CreatedOn),

            });
            return departmentToReturn;
        }

        public DepartmentDetailsDto? GetById(int id)
        {
            var dept = _departmentRepository.GetById(id);
            if (dept is null) return null;
            else
            {
                var deptToReturn = new DepartmentDetailsDto()
                {
                    Id = dept.Id,
                    Name = dept.Name,
                    Code = dept.Code,
                    CreatedBy = dept.CreatedBy,
                    LastModifiedBy = dept.LastModifiedBy,
                    IsDeleted = dept.IsDeleted,
                    LastModifiedOn = DateOnly.FromDateTime(dept.LastModifiedOn),




                };

                return deptToReturn;
            }
            //manual mapping
            //return dept is null ? null : new DepartmentDetailsDto()
            //{
            //    Id = dept.Id,
            //    Name = dept.Name,
            //    Code = dept.Code,
            //    CreatedBy = dept.CreatedBy,
            //    LastModifiedBy = dept.LastModifiedBy,
            //    IsDeleted = dept.IsDeleted,
            //    LastModifiedOn = DateOnly.FromDateTime(dept.LastModifiedOn),

            //};

            //return dept is null ? null : new DepartmentDetailsDto(dept);//constractor mapping
            return dept is null ? null : dept.ToDepartmentDetailsDto();  //Extension mapping
        }

        public int AddDepartment(CreatedDepartmentDto departmentDto)
        {
            var entity = departmentDto.ToEntity();
            return _departmentRepository.Add(entity);
        }

        public int UpdateDepartment(UbdateDepartmentDto departmentDto)
        {
            var entity = departmentDto.ToEntity();
            return _departmentRepository.Update(departmentDto.ToEntity());
        }


        public bool DeleteDepartment(int id)
        {
            var department = _departmentRepository.GetById(id);
            if (department is null) return false;
            else
            {
                var res = _departmentRepository.Delete(department);
                if (res > 0) return true;
                else return false;
            }
            ;
        }
        }

    }
