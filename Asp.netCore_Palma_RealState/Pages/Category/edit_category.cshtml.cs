using Asp.netCore_Palma_RealState.Data;
using Asp.netCore_Palma_RealState.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Asp.netCore_Palma_RealState.Pages.Category
{
    public class edit_categoryModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public edit_categoryModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty] public T_category t_category { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            t_category = await _context.T_category.FirstOrDefaultAsync(m => m.ID_category == id);

            if (t_category == null)
            {
                return NotFound();
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Update(t_category);
            await _context.SaveChangesAsync();

            return RedirectToPage("show_all_category");
        }
    }
}
