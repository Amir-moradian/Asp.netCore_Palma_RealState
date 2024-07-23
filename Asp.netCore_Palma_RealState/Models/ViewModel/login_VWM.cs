using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Asp.netCore_Palma_RealState.Models.ViewModel
{
    public class login_VWM
    {
        [Required]
       public string phone { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }

        public string? ReturnUrl { get; set; }

        [TempData]
        public string? ErrorMessage { get; set; }

    }
}
