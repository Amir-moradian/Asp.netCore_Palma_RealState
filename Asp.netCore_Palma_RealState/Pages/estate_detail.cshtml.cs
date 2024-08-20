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

        public async Task<IActionResult> OnPost(int id)
        {
            if (User == null || !User.Identity.IsAuthenticated) // چک میکند کاربر وارد حساب کاربری شده یا نه
            {
                return Redirect("/Identity/Account/Login?returnUrl=/estate_detail?id=" + id);
            }

            if (id <= 0)
            {
                return NotFound();
            }

            var chek_estate = await _context.T_estate.FirstOrDefaultAsync(e => e.ID_estate == id);// چک میکند آیا ملکی موجود هست یا نه 

            if (chek_estate is null)
            {
                return NotFound();
            }

            var user_id = await _context.Users.FirstOrDefaultAsync(u => u.UserName == User.Identity.Name);// آیدی کاربر

            var chek_favorit = await _context.T_favourite
                .FirstOrDefaultAsync(f => f.id_user == user_id.Id && f.id_estate == id);// چک برای انتخاب بودن 
            if (chek_favorit == null)
            {
                await _context.T_favourite.AddAsync(new T_favourite()
                {
                    id_estate = id,
                    id_user = user_id.Id
                });
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("estate_detail", new { id });
        }

    }
}
