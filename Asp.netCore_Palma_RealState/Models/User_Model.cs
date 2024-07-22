using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;

namespace Asp.netCore_Palma_RealState.Models
{
    public class User_Model : IdentityUser
    {

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "لطفانام کامل خود را وارد کنید")]
        [MaxLength(100, ErrorMessage = "نام کامل نمی تواند بیشتر از 100 کاراکتر باشد ")]
        public string? full_name { get; set; }
    }
}
