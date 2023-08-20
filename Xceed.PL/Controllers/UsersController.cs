using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Claims;
using Xceed.DAL.Entities;

namespace Xceed.PL.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserManager<AppUser> userManager;

        public UsersController(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }

        [Authorize(Roles = "admin")]
        public IActionResult Index()
        {
            var users = userManager.Users;
            return View(users);
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            var data = await userManager.FindByIdAsync(id);
            return View(data);
        }


        [HttpGet]
        [Authorize(Roles = "subAdmin ,admin ,user")]
        public async Task<IActionResult> EditProfile()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var user = await userManager.FindByEmailAsync(email);
            return View(user);
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var data = await userManager.FindByIdAsync(id);
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(AppUser model)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    var user = await userManager.FindByIdAsync(model.Id);

                    user.DisplayName = model.DisplayName;
                    user.Email = model.Email;
                    user.PhoneNumber = model.PhoneNumber;
                    user.SecurityStamp = model.SecurityStamp;

                    var result = await userManager.UpdateAsync(user);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        foreach (var item in result.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                        }
                    }


                }
                return View(model);

            }
            catch (Exception ex)
            {
                return View(model);
            }

        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            var data = await userManager.FindByIdAsync(id);
            return View(data);
        }


        [HttpPost]
        public async Task<IActionResult> Delete(IdentityUser model)
        {

            try
            {

                if (ModelState.IsValid)
                {

                    var user = await userManager.FindByIdAsync(model.Id);

                    var result = await userManager.DeleteAsync(user);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        foreach (var item in result.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                        }
                    }


                }

                return View(model);

            }
            catch (Exception ex)
            {
                return View(model);
            }

        }

    }
}
