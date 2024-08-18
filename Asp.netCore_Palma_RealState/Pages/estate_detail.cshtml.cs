using Asp.netCore_Palma_RealState.Data;
using Asp.netCore_Palma_RealState.Models;
using Asp.netCore_Palma_RealState.Models.ViewModel;
using Asp.netCore_Palma_RealState.Models.ViewModel.EstateViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Asp.netCore_Palma_RealState.Pages
{
    public class estate_detailModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public estate_detailModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public estate_detail_VWM? estate_detail_VWM { get; set; }

        public T_estate t_estate { get; set; }
        public async Task<IActionResult> OnGet(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            t_estate = await _context.T_estate
                   .Include(c => c.t_category)
                   .FirstOrDefaultAsync(e => e.ID_estate == id);

            if (t_estate == null)
            {
                return NotFound();
            }

            estate_detail_VWM = new()
            {
                t_estate = t_estate,
                sugest_pro = _context.T_estate
                    .Include(c => c.t_category)
                    .Where(e => e.ID_estate != t_estate.ID_estate)
                    .Take(4)
                    .ToList()
            };


            return Page();
        }
    }
}
