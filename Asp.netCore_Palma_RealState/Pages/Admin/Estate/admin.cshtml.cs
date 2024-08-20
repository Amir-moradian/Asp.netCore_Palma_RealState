using Asp.netCore_Palma_RealState.Data;
using Asp.netCore_Palma_RealState.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Asp.netCore_Palma_RealState.Pages.Admin.Estate
{
    public class adminModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public adminModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<T_estate> show_all_estate { get; set; }

        public async Task<IActionResult> OnGet()
        {
            //show_all_estate = await _context.T_estate.ToListAsync();
            //return Page();

            show_all_estate = await _context.T_estate
              .Include(c => c.t_category)
                .ToListAsync();
            return Page();
            
        }
    }
}
