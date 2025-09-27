using AutoMapper;
using Demo.BusinessLogic.Services.Classes;
using Demo.DataAccess.Entities.IdentityEntities;
using Demo.Presentation.ViewModels.UserViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Demo.Presentation.Controllers
{
    public class UsersController(UserManager<ApplicationUser> userManager,
                                 IWebHostEnvironment webHostEnvironment,
                                 ILogger<UsersController> logger,
                                 IMapper mapper) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index(string searchValue)
        {
            if (string.IsNullOrWhiteSpace(searchValue)) {
                var users = await userManager.Users.ToListAsync();

                // don't use async inside EF Query
                var userVMs = new List<UserVM>();
                foreach(var user in users)
                {
                    var roles = await userManager.GetRolesAsync(user);
                    userVMs.Add(new UserVM()
                    {
                        Email = user.Email,
                        Fname = user.FirstName,
                        Lname = user.LastName,
                        Id = user.Id,
                        PhoneNumber = user.PhoneNumber,
                        Roles = roles
                    });
                }
                return View(userVMs);
            }
            else
            {
                ApplicationUser? user = await userManager.FindByEmailAsync(searchValue);
                if (user is null)
                {
                    return View(new List<UserVM>());
                }
                IList<string>? roles = await userManager.GetRolesAsync(user);
                var userVM = new UserVM()
                {
                    Email = user.Email,
                    Fname = user.FirstName,
                    Lname = user.LastName,
                    Id = user.Id,
                    PhoneNumber = user.PhoneNumber,
                    Roles = roles
                };
                return View(new List<UserVM> { userVM });
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(string? id)
        {
            if (string.IsNullOrWhiteSpace(id)) return BadRequest();
            else
            {
                try
                {
                    ApplicationUser? user = await userManager.FindByIdAsync(id.ToString());
                    if (user is null) return NotFound();
                    else
                    {
                        IdentityResult? isDeleted = await userManager.DeleteAsync(user);
                        if (!isDeleted.Succeeded)
                        {
                            ModelState.AddModelError("", "User is not deleted");
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
                ApplicationUser? user = await userManager.FindByIdAsync(id);
                if (user is null) return NotFound();
                else
                {
                    var userVM = mapper.Map<UserVM>(user);
                    return View(viewName, userVM);
                }
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string? id)
        {
            return await Details(id, "Edit");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserVM userVM, [FromRoute] string Id)
        {
            if (Id != userVM.Id) return BadRequest();
            else
            {
                try
                {
                    ApplicationUser? User = await userManager.FindByIdAsync(Id);
                    if (User is null) return NotFound();
                    User.PhoneNumber = userVM.PhoneNumber;
                    User.FirstName = userVM.Fname;
                    User.LastName = userVM.Lname;
                    IdentityResult? result = await userManager.UpdateAsync(User);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return View(userVM);
                }
            }
        }
    }
}
