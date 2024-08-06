using Microsoft.AspNetCore.Mvc.Rendering;

namespace Asp.netCore_Palma_RealState.Models.ViewModel.EstateViewModel
{
    public class add_estate_VWM
    {
        public T_estate? t_Estate { get; set; }
        public IFormFile? img_up { get; set; }
        public SelectList? category_option { get; set; }
        public string? select_category { get; set; }
         
    }
}
