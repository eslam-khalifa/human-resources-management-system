using Demo.BusinessLogic.Services.Classes;
using Demo.BusinessLogic.Services.Interfaces;
using Demo.BusinessLogic.DataTransferObjects.EmployeeDTOs;
using Demo.DataAccess.Entities.EmployeEntities;
using Microsoft.AspNetCore.Mvc;
using Demo.Presentation.ViewModels.EmployeeViewModels;
using Demo.DataAccess.Entities.Shared.Enums;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace Demo.Presentation.Controllers
{
    [Authorize]
    public class EmployeesController(IEmployeeService employeeService,
                                     IWebHostEnvironment webHostEnvironment,
                                     ILogger<EmployeesController> logger) : Controller
    {
        public async Task<IActionResult> Index(string? searchName)
        {
            var employees = await employeeService.GetAllAsync(searchName);
            return View(employees);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var vm = new EmployeeVM
            {
                HiringDate = DateOnly.FromDateTime(DateTime.Now),
                IsActive = true,
                Gender = Gender.Male
            };
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeVM employeeVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    CreatedEmployeeDTO? createdEmployeeDTO = new CreatedEmployeeDTO
                    {
                        Address = employeeVM.Address,
                        Age = employeeVM.Age,
                        CreatedBy = employeeVM.CreatedBy,
                        DepartmentId = employeeVM.DepartmentId,
                        Email = employeeVM.Email,
                        EmployeeType = employeeVM.EmployeeType.ToString(),
                        Gender = employeeVM.Gender.ToString(),
                        HiringDate = employeeVM.HiringDate,
                        IsActive = employeeVM.IsActive,
                        LastModifiedBy = employeeVM.LastModifiedBy,
                        Name = employeeVM.Name,
                        PhoneNumber = employeeVM.PhoneNumber,
                        Salary = employeeVM.Salary,
                        Image = employeeVM.Image
                    };
                    int result = await employeeService.CreateAsync(createdEmployeeDTO);
                    if (result > 0) return RedirectToAction(nameof(Index));
                    else
                    {
                        ModelState.AddModelError("", "Can't Create Employee");
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
                        // return Error Page
                    }
                }
            }

            return View(employeeVM);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id is null) return BadRequest();

            EmployeeDetailsDTO? employeeDetailsDTO = await employeeService.GetByIdAsync<EmployeeDetailsDTO>(id);

            if (employeeDetailsDTO is not null)
            {
                return View(employeeDetailsDTO);
            }

            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null || id <= 0) return BadRequest();

            UpdatedEmployeeDTO updatedEmployeeVM = await employeeService.GetByIdAsync<UpdatedEmployeeDTO>(id);

            EmployeeVM employeeVM = new EmployeeVM
            {
                Salary = updatedEmployeeVM.Salary,
                PhoneNumber = updatedEmployeeVM.PhoneNumber,
                Name = updatedEmployeeVM.Name,
                LastModifiedBy = updatedEmployeeVM.LastModifiedBy,
                IsActive = updatedEmployeeVM.IsActive,
                HiringDate = updatedEmployeeVM.HiringDate,
                Gender = Enum.Parse<Gender>(updatedEmployeeVM.Gender),
                Address = updatedEmployeeVM.Address,
                Age = updatedEmployeeVM.Age,
                CreatedBy = updatedEmployeeVM.CreatedBy,
                DepartmentId = updatedEmployeeVM.DepartmentId,
                Email = updatedEmployeeVM.Email,
                EmployeeType = Enum.Parse<EmployeeType>(updatedEmployeeVM.EmployeeType),
                IsEditMode = true,
                Image = updatedEmployeeVM.Image,
                ImageName = updatedEmployeeVM.ImageName
            };

            if (updatedEmployeeVM is not null)
            {
                return View(employeeVM);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromRoute] int? id, EmployeeVM employeeVM)
        {
            if (id is null || id <= 0) return BadRequest();

            if (ModelState.IsValid)
            {
                try
                {
                    var updatedEmployeeDTO = new UpdatedEmployeeDTO
                    {
                        Id = id.Value,
                        EmployeeType = employeeVM.EmployeeType.ToString(),
                        Address = employeeVM.Address,
                        Age= employeeVM.Age,
                        CreatedBy= employeeVM.CreatedBy,
                        DepartmentId = employeeVM.DepartmentId,
                        Email = employeeVM.Email,
                        Gender = employeeVM.Gender.ToString(),
                        HiringDate = employeeVM.HiringDate,
                        IsActive = employeeVM.IsActive,
                        LastModifiedBy = employeeVM.LastModifiedBy,
                        Name = employeeVM.Name,
                        PhoneNumber = employeeVM.PhoneNumber,
                        Salary = employeeVM.Salary,
                        Image = employeeVM.Image,
                        ImageName = employeeVM.ImageName
                    };
                    int result = await employeeService.UpdateAsync(updatedEmployeeDTO);
                    if (result != 0)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    ModelState.AddModelError("", "Can't update Employee");
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
                        // return Error Page
                    }
                }
            }

            return View(employeeVM);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null || id <= 0) return BadRequest();
            try
            {
                int? result = await employeeService.DeleteAsync(id.Value);
                if (result is null) return BadRequest();
                else
                {
                    if (result == 0)
                    {
                        ModelState.AddModelError("", "Can't delete employee");
                    }
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
            return RedirectToAction(nameof(Index));
        }
    }
}
