
namespace Demo.DAL.Repositories
{
    public interface IDepartmentRepository
    {
        int Add(Department department);
        int Delete(Department department);
        int Update(Department department);
        IEnumerable<Department> GetAll(bool withTracking = false);
        Department? GetById(int id);
       
    }
}