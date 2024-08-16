using Microsoft.AspNetCore.Mvc;

namespace Asp.netCore_Palma_RealState.Component
{
    [ViewComponent(Name = "admin_Menu")]
    public class admin_menu:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("/Pages/Shared/ViewComponent/admin_VWC.cshtml");

        }
    }
}
