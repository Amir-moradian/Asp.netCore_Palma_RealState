using Asp.netCore_Palma_RealState.Data;
using Asp.netCore_Palma_RealState.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Asp.netCore_Palma_RealState.Pages
{
    public class all_estateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public all_estateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<T_estate> t_estate_model { get; set; }
        public async Task<IActionResult> OnGet()
        {
            t_estate_model = await _context
                .T_estate
               .ToListAsync();
            return Page();
        }
    }
}
