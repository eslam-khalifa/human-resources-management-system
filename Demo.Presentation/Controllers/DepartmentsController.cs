using Microsoft.AspNetCore.Mvc;
using Demo.BusinessLogic.DataTransferObjects;
using Demo.BusinessLogic.Mappings;
using Demo.Presentation.ViewModels.DepartmentsViewModels;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Demo.BusinessLogic.DataTransferObjects.DepartmentDTOs;
using Demo.BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace Demo.Presentation.Controllers
{
    // [AllowAnonymous]
    [Authorize]
    public class DepartmentsController(IDepartmentService departmentService,
        ILogger<DepartmentsController> logger,
        IWebHostEnvironment webHostEnvironment) : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var departments = departmentService.GetAll();
            return View(departments);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(DepartmentVM departmentVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var createdDepartmentDto = new CreatedDepartmentDTO
                    {
                        Code = departmentVM.Code,
                        DateOfCreation = departmentVM.DateOfCreation,
                        Description = departmentVM.Description,
                        Name = departmentVM.Name
                    };
                    int Result = await departmentService.CreateAsync(createdDepartmentDto);
                    if (Result > 0)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Something went wrong");
                    }
                }
                catch (Exception ex)
                {
                    if (webHostEnvironment.IsDevelopment())
                    {
                        ModelState.AddModelError("", ex.Message);
                    }
                    else
                    {
                        logger.LogError(ex.Message);
                    }
                }
            }
            return View(departmentVM);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (!id.HasValue) return BadRequest();
            var department = await departmentService.GetByIdAsync(id.Value);
            if (department == null) return NotFound();
            {
                return View(department);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (!id.HasValue) return BadRequest();
            var department = await departmentService.GetByIdAsync(id);
            if(department == null) return NotFound();
            var departmentViewModel = new DepartmentVM
            {
                Code = department.Code,
                Name = department.Name,
                Description = department.Description,
                DateOfCreation = department.CreatedOn
            };
            return View(departmentViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromRoute] int? id, DepartmentVM departmentVM)
        {
            if (id is null) return BadRequest();
            if (ModelState.IsValid)
            {
                try
                {
                    var updatedDepartmentDto = new UpdatedDepartmentDTO
                    {
                        Id = id.Value,
                        Name = departmentVM.Name,
                        Code = departmentVM.Code,
                        Description = departmentVM.Description,
                        DateOfCreation = departmentVM.DateOfCreation
                    };
                    int Result = await departmentService.UpdateAsync(updatedDepartmentDto);
                    if (Result > 0)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Something went wrong");
                    }
                }
                catch (Exception ex)
                {
                    if (webHostEnvironment.IsDevelopment())
                    {
                        ModelState.AddModelError("", ex.Message);
                    }
                    else
                    {
                        logger.LogError(ex.Message);
                        return View("ErrorView", ex);
                    }
                }
            }
            return View(departmentVM);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var isDeleted = await departmentService.DeleteAsync(id);
                if (isDeleted <= 0)
                {
                    ModelState.AddModelError("", "Department is not deleted");
                    return RedirectToAction(nameof(Index), new { id });
                }
            }
            catch (Exception ex)
            {
                if (webHostEnvironment.IsDevelopment())
                {
                    ModelState.AddModelError("", ex.Message);
                }
                else
                {
                    logger.LogError(ex.Message);
                    return View("ErrorView", ex);
                }
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
