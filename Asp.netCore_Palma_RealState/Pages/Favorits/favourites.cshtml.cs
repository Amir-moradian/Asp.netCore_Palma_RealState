using Asp.netCore_Palma_RealState.Data;
using Asp.netCore_Palma_RealState.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Asp.netCore_Palma_RealState.Pages.Favorits
{
    [Authorize]
    public class favouritesModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public favouritesModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<T_favourite> t_favourite { get; set; }
        public async Task<IActionResult> OnGet()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Redirect("/Identity/Account/Login?returnUrl=/Favorits");
            }
            var use_id = await _context.Users.FirstOrDefaultAsync(u => u.UserName == User.Identity.Name);

            t_favourite = await _context.T_favourite
                .Include(e => e.t_estate)
                .Where(f => f.id_user == use_id.Id).ToListAsync();

            return Page();

        }
    }
}
