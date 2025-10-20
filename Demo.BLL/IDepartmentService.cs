using Demo.BLL.DTOs;

namespace Demo.BLL
{
    public interface IDepartmentService
    {
        int AddDepartment(CreatedDepartmentDto departmentDto);
        bool DeleteDepartment(int id);
        IEnumerable<DepartmentDTOs> GetAllDepartments();
        DepartmentDetailsDto? GetById(int id);
        int UpdateDepartment(UbdateDepartmentDto departmentDto);
    }
}