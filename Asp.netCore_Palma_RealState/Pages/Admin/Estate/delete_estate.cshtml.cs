using Asp.netCore_Palma_RealState.Data;
using Asp.netCore_Palma_RealState.Models;
using Asp.netCore_Palma_RealState.Models.ViewModel.EstateViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Asp.netCore_Palma_RealState.Pages.Admin.Estate
{
    public class delete_estateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public delete_estateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public estate_VWM estate_vwm { get; set; }
    public async Task<IActionResult> OnGet(int Id)
        {
            if (Id <= 0)
            {
                return NotFound();
            }

           
                //estate_vwm = await _context.T_estate.FirstOrDefaultAsync(e => e.ID_estate == Id);

           

            if (estate_vwm is null)
            {
                return NotFound();
            }

            return Page();
        }
        public async Task<IActionResult> OnPost()
        {
            if (estate_vwm.t_Estate.ID_estate <= 0)
            {
                return NotFound();
            }
            if (estate_vwm.t_Estate.image is not null)
            {
                string saveDir = "wwwroot/image/Estates";
                string deletePath = Path.Combine(Directory.GetCurrentDirectory(), saveDir, estate_vwm.t_Estate.image);
                if (System.IO.File.Exists(deletePath))
                    System.IO.File.Delete(deletePath);
            }
            _context.Remove(estate_vwm);
            await _context.SaveChangesAsync();


            return RedirectToPage("admin");
        }
    }

}

