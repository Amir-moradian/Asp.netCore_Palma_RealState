// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using Asp.netCore_Palma_RealState.Data;
using Asp.netCore_Palma_RealState.Extention;
using Asp.netCore_Palma_RealState.Models;
using Asp.netCore_Palma_RealState.Models.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Asp.netCore_Palma_RealState.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<User_Model> _signInManager;
        private readonly UserManager<User_Model> _userManager;
        private readonly IUserStore<User_Model> _userStore;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _appDbContext;

        public RegisterModel(SignInManager<User_Model> signInManager, UserManager<User_Model> userManager, IUserStore<User_Model> userStore, RoleManager<IdentityRole> roleManager, ApplicationDbContext appDbContext)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _userStore = userStore;
            _roleManager = roleManager;
            _appDbContext = appDbContext;
        }

        [BindProperty]
        public register_VWM Input { get; set; }


        public async Task OnGetAsync(string returnUrl = null)
        {
            Input = new register_VWM()
            {
                ReturnUrl = returnUrl
            };
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            if (ModelState.IsValid)
            {
                var user = CreateUser();

                await _userStore.SetUserNameAsync(user, Input.phone, CancellationToken.None);
                var result = await _userManager.CreateAsync(user, Input.Password);
                user.full_name = Input.full_name;
                user.PhoneNumber = Input.phone;
                if (result.Succeeded)
                {
                    if (!await _roleManager.RoleExistsAsync(rols.Admin))
                    {
                        await _roleManager.CreateAsync(new IdentityRole(rols.Admin));
                    }
                    if (!await _roleManager.RoleExistsAsync(rols.User))
                    {
                        await _roleManager.CreateAsync(new IdentityRole(rols.User));
                    }

                    if (_appDbContext.Users.ToList().Count == 1)
                    {
                        await _userManager.AddToRoleAsync(user, rols.Admin);
                    }
                    else
                    {
                        await _userManager.AddToRoleAsync(user, rols.User);
                    }



                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }


            return Page();
        }

        private User_Model CreateUser()
        {
            try
            {
                return Activator.CreateInstance<User_Model>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(IdentityUser)}'. " +
                    $"Ensure that '{nameof(IdentityUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }

    }
}
