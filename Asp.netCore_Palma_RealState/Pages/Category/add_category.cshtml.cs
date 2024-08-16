using Asp.netCore_Palma_RealState.Data;
using Asp.netCore_Palma_RealState.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Asp.netCore_Palma_RealState.Pages.Category
{
    public class add_categoryModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public add_categoryModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public T_category t_category { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _context.T_category.AddAsync(t_category);
            await _context.SaveChangesAsync();

            return RedirectToPage("show_all_category");
        }






    }
}
