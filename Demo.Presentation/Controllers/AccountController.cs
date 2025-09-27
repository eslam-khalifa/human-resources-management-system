using Demo.DataAccess.Entities.IdentityEntities;
using Demo.Presentation.Utilities;
using Demo.Presentation.ViewModels.AccountViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Threading.Tasks;

namespace Demo.Presentation.Controllers
{
    public class AccountController(UserManager<ApplicationUser> userManager,
                                   SignInManager<ApplicationUser> signInManager) : Controller
    {
        [HttpGet]
        public IActionResult Register() => View();

        [HttpPost]
        public IActionResult Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid)
            {
                return View(registerVM);
            }

            var User = new ApplicationUser
            {
                FirstName = registerVM.FirstName,
                LastName = registerVM.LastName,
                UserName = registerVM.UserName,
                Email = registerVM.Email
            };

            // Result makes the returned value Sync not Async
            // CreateAsync method has custom validation for password which is applied directly on the password but you can edit the criteria by passing action to AddIdentity method
            var Result = userManager.CreateAsync(User, registerVM.Password).Result;
            if (Result.Succeeded)
            {
                return RedirectToAction(nameof(Login));
            }
            else
            {
                foreach (var error in Result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View(registerVM);
            }
        }

        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (ModelState.IsValid)
            {
                var User = await userManager.FindByEmailAsync(loginVM.Email);
                if (User is not null)
                {
                    var Result = await userManager.CheckPasswordAsync(User, loginVM.Password);
                    if (Result)
                    {
                        var LoginResult = await signInManager.PasswordSignInAsync(User, loginVM.Password, loginVM.RememberMe, false);
                        if (LoginResult.Succeeded)
                        {
                            return RedirectToAction("index", "Home");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Password is not correct");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Email doesn't exist");
                }
            }
            return View(loginVM);
        }

        [HttpGet]
        public new async Task<IActionResult> SignOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }

        [HttpGet]
        public IActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendResetPasswordLink(ForgetPasswordVM forgetPasswordVM)
        {
            if (ModelState.IsValid)
            {
                var User = await userManager.FindByEmailAsync(forgetPasswordVM.Email);

                if (User is not null)
                {
                    var token = userManager.GeneratePasswordResetTokenAsync(User);
                    var ResetPasswordLink = Url.Action("ResetPassword", "Account", new { email = forgetPasswordVM.Email, token }, Request.Scheme);
                    var email = new Email()
                    {
                        To = forgetPasswordVM.Email,
                        Subject = "Reset Password",
                        Body = ResetPasswordLink
                    };
                    EmailSettings.SendEmail(email);
                    return RedirectToAction(nameof(CheckYourInbox));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid Operation");
                }
            }

            return View(nameof(ForgetPassword), forgetPasswordVM);
        }

        [HttpGet]
        public IActionResult CheckYourInbox()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ResetPassword(string email, string token)
        {
            TempData["email"] = email;
            TempData["token"] = token;
            return View();
        }

        [HttpPost]
        public IActionResult ResetPassword(ResetPasswordVM resetPasswordVM)
        {
            if (ModelState.IsValid)
            {
                string email = TempData["email"]?.ToString() ?? string.Empty;
                string token = TempData["token"]?.ToString() ?? string.Empty;
                ApplicationUser? User = userManager.FindByEmailAsync(email).Result;
                if (User is null)
                {
                    ModelState.AddModelError(string.Empty, "Invalid Operation");
                    return View(resetPasswordVM);
                }
                else
                {
                    var Result = userManager.ResetPasswordAsync(User, token, resetPasswordVM.Password).Result;
                    if (Result.Succeeded)
                    {
                        return RedirectToAction(nameof(Login));
                    }
                    else
                    {
                        foreach (var error in Result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
            }

            return View(nameof(ResetPassword), resetPasswordVM);
        }
    }
}
