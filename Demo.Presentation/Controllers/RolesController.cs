using AutoMapper;
using Demo.DataAccess.Entities.IdentityEntities;
using Demo.Presentation.ViewModels.RoleViewModels;
using Demo.Presentation.ViewModels.UserViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Demo.Presentation.Controllers
{
    public class RolesController(RoleManager<IdentityRole> roleManager,
                                IMapper mapper,
                                IWebHostEnvironment webHostEnvironment,
                                ILogger<RolesController> logger) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index(string? searchValue)
        {
            if (string.IsNullOrEmpty(searchValue))
            {
                List<IdentityRole>? roles = await roleManager.Roles.ToListAsync();
                var rolesVM = mapper.Map<List<RoleVM>>(roles);
                return View(rolesVM);
            }
            else
            {
                IdentityRole? role = await roleManager.FindByNameAsync(searchValue);
                if (role is null) return View(new List<RoleVM>());
                var roleVM = mapper.Map<RoleVM>(role);
                return View(new List<RoleVM> { roleVM });
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RoleVM roleVM)
        {
            IdentityRole? role = mapper.Map<IdentityRole>(roleVM);
            IdentityResult? result = await roleManager.CreateAsync(role);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(string? id)
        {
            if (string.IsNullOrWhiteSpace(id)) return BadRequest();
            else
            {
                try
                {
                    var role = await roleManager.FindByIdAsync(id.ToString());
                    if (role is null) return NotFound();
                    else
                    {
                        IdentityResult? isDeleted = await roleManager.DeleteAsync(role);
                        if (!isDeleted.Succeeded)
                        {
                            ModelState.AddModelError("", "role is not deleted");
                            return RedirectToAction(nameof(Index), new { id });
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
                        return View("ErrorView", ex);
                    }
                }
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(string? id, string viewName = "Details")
        {
            if (string.IsNullOrWhiteSpace(id)) return BadRequest();
            else
            {
                var role = await roleManager.FindByIdAsync(id);
                if (role is null) return NotFound();
                else
                {
                    var roleVM = mapper.Map<RoleVM>(role);
                    return View(viewName, roleVM);
                }
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string? id)
        {
            return await Details(id, "Edit");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(RoleVM roleVM, [FromRoute] string Id)
        {
            if (Id != roleVM.Id) return BadRequest();
            else
            {
                try
                {
                    var role = await roleManager.FindByIdAsync(Id);
                    if (role is null) return NotFound();
                    role.Name = roleVM.RoleName;
                    IdentityResult? result = await roleManager.UpdateAsync(role);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return View(roleVM);
                }
            }
        }
    }
}
