using Asp.netCore_Palma_RealState.Data;
using Asp.netCore_Palma_RealState.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Asp.netCore_Palma_RealState.Component
{
    [ViewComponent(Name = "header_name")]
    public class header:ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public header(ApplicationDbContext context)
        {
            _context = context;
        }
     


        public async Task<IViewComponentResult> InvokeAsync()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user_claim = await _context.User_Model
                    .FirstOrDefaultAsync(a => a.UserName == User.Identity.Name);

                header_VWM model_header = new()
                {
                    full_name = user_claim.full_name
                };
                return View("/Pages/Shared/ViewComponent/header_VWC.cshtml",model_header);
            }
            return View("/Pages/Shared/ViewComponent/header_VWC.cshtml",new header_VWM());
        }
    }
}
