using System.ComponentModel.DataAnnotations;

namespace Asp.netCore_Palma_RealState.Models.ViewModel
{
    public class register_VWM
    {
        [Required]
       [Display(Name = "phone")]
        public string phone { get; set; }


        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }


        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "لطفانام کامل خود را وارد کنید")]
        [MaxLength(100, ErrorMessage = "نام کامل نمی تواند بیشتر از 100 کاراکتر باشد ")]
        public string? full_name { get; set; }

        public string? ReturnUrl { get; set; }

    }
}
