using Demo.BLL;
using Microsoft.AspNetCore.Mvc;
namespace WebApplication2.Controllers
{
    public class DepartmentController(IDepartmentService _departmentService) :Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var departments= _departmentService.GetAllDepartments();
            return View(departments);
        }
    }
}
