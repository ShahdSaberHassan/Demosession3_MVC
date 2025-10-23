using Demo.BLL;
using Demo.BLL.DTOs;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.ViewModels.DepartmentViewModel;
namespace WebApplication2.Controllers
{
    public class DepartmentController :Controller
    {
        private readonly IDepartmentService _departmentService;
        private readonly ILogger<HomeController>_logger;
        private readonly IWebHostEnvironment _environment;

        public DepartmentController(IDepartmentService departmentService, ILogger<HomeController> logger   ,IWebHostEnvironment environment)
        {
            _departmentService = departmentService;
        _logger= logger;
        _environment =_environment;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var departments= _departmentService.GetAllDepartments();
            return View(departments);
        }


        #region Create

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(AddDepartmentDto departmentDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int res = _departmentService.AddDepartment(departmentDto);
                    if (res > 0) return RedirectToAction(nameof(Index));
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Department can't Be Added");
                        return View(departmentDto);
                    }
                }
                catch (Exception ex) 
                {
                    //log exception

                    if (_environment.IsDevelopment())
                    {
                        //development
                        ModelState.AddModelError(string.Empty, ex.Message);
                        return View(departmentDto);
                    }
                    else
                    {
                        //deploymnet
                        //_logger.LogError(ex.Message);
                        return View(departmentDto);

                    }
                }
            }
            return View(departmentDto);
        }
        #endregion



        #region Details

        public IActionResult Details(int? id)
        {
            if (!id.HasValue) return BadRequest();

            var department = _departmentService.GetById(id.Value);

            if (department == null) return NotFound();

            return View(department);
        }



        #endregion



        #region Edit

        [HttpGet]
        public ActionResult Edit(int? id) 
        { 
        if(!id.HasValue)return BadRequest();

        var department= _departmentService.GetById(id.Value);
            if (department == null) return NotFound();

            var deptViewModel = new DepartmentEditViewModel()
            {
              
                Name = department.Name,
                Code=department.Code,
                DatOfCreation=department.DateOfCreation,
                Description=department.Description,

            };

            return View(deptViewModel);

        }


        [HttpPost]
        public ActionResult Edit([FromRoute] int id, DepartmentEditViewModel viewModel)
        {
            if (!ModelState.IsValid) return View(viewModel);
            try
            {
                var updateDeptDto = new UbdateDepartmentDto()
                {
                    Id =id,
                    Code = viewModel.Code,
                    Name = viewModel.Name,
                    Description = viewModel.Description,
                    DatOfCreation = viewModel.DatOfCreation
                };
                var res = _departmentService.UpdateDepartment(updateDeptDto);
                if(res > 0) return RedirectToAction(nameof(Index));
                return View(viewModel);
            }
            catch (Exception ex)
            {
                return View(viewModel);
            }
        }
        #endregion

        #region Delete
        //[HttpGet]
        //public IActionResult Delete(int? id) 
        //{
        //    if(!id.HasValue) return BadRequest();
        //    var dept =_departmentService.GetById(id.Value);
        //    if(dept is null) return NotFound();
        //    return View(dept);
        //}

        [HttpPost]
        public IActionResult Delete(int id)
        {

            if (id == 0) return BadRequest();
            try
            {
                bool isDeleted = _departmentService.DeleteDepartment(id);
                if (isDeleted)
                    return RedirectToAction(nameof(Index));
                else ModelState.AddModelError(string.Empty, "Department can't Be Deleted");
                return RedirectToAction(nameof(Delete),new {id});

            }
            catch (Exception ex)
            {
                //log exception

                if (_environment.IsDevelopment())
                {
                    //development
                    ModelState.AddModelError(string.Empty, ex.Message);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    //deploymnet
                    //_logger.LogError(ex.Message);
                    return View("Error view", ex);

                }

            }
        }


        #endregion

    }
}
