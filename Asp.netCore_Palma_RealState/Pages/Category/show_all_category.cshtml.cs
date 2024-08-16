using Asp.netCore_Palma_RealState.Data;
using Asp.netCore_Palma_RealState.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Asp.netCore_Palma_RealState.Pages.Category
{
    public class show_all_categoryModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public show_all_categoryModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<T_category> show_al_category { get; set; }

        public async Task<IActionResult> OnGet()
        {
            show_al_category = await _context.T_category.ToListAsync();
            return Page();

        }
    }
}
