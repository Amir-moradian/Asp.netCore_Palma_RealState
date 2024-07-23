// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using Asp.netCore_Palma_RealState.Models;
using Asp.netCore_Palma_RealState.Models.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Asp.netCore_Palma_RealState.Areas.Identity.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly SignInManager<User_Model> _signInManager;
        private readonly ILogger<LoginModel> _logger;

        public LoginModel(SignInManager<User_Model> signInManager)
        {
            _signInManager = signInManager;
        }

        [BindProperty]
        public login_VWM Input { get; set; }

      public async Task OnGetAsync(string returnUrl = null)
      {
          Input = new login_VWM();
            if (!string.IsNullOrEmpty(Input.ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, Input.ErrorMessage);
            }

            returnUrl ??= Url.Content("~/");

            if (User.Identity.IsAuthenticated)
            {
                LocalRedirect(returnUrl);
            }
           
            Input.ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(Input.phone, Input.Password, Input.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                   return LocalRedirect(returnUrl);
                }
                if (result.IsLockedOut)
                {
                    _logger.LogWarning("User account locked out.");
                    return RedirectToPage("./Lockout");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return Page();
                }
            }

            return Page();
        }

    }
}
