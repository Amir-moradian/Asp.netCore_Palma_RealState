using Asp.netCore_Palma_RealState.Data;
using Asp.netCore_Palma_RealState.Models;
using Asp.netCore_Palma_RealState.Models.ViewModel.EstateViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Asp.netCore_Palma_RealState.Pages.Admin.Estate
{
    public class edit_estateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public edit_estateModel(ApplicationDbContext context)
        {
            _context = context;
        }
        private void init_category()
        {
            Estate_VWM = new()
            {
                category_option = new SelectList(_context.T_category,
                    nameof(T_category.ID_category),
                    nameof(T_category.tittle))
            };
        }
        [BindProperty]
        public estate_VWM Estate_VWM { get; set; }
        public async Task<IActionResult> OnGet(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var estate = await _context.T_estate.FindAsync(id);
            if (estate == null)
            {
                return NotFound();
            }

           init_category();
            Estate_VWM.t_Estate = estate;
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid && string.IsNullOrEmpty(Estate_VWM.select_category))
            {
                init_category();
                return Page();
            }

            bool chek = int.TryParse(Estate_VWM.select_category, out int id_Category);
            if (chek is false)
            {
                ModelState.AddModelError(string.Empty, "دسته بندی انتخاب شده معتبر نمی باشد");
                init_category();
                return Page();

            }

            var cat_id_fake = await _context.T_category.FindAsync(id_Category);

            if (cat_id_fake is null)
            {
                ModelState.AddModelError(string.Empty, "دسته بندی انتخاب شده معتبر نمی باشد");

                init_category();
                return Page();
            }

            if (Estate_VWM.img_up is not null)
            {
                string saveDir = "wwwroot/image/Estates";

                if (Estate_VWM.t_Estate.image is not null)
                {
                    string deletePath = Path.Combine(Directory.GetCurrentDirectory(), saveDir, Estate_VWM.t_Estate.image);
                    if (System.IO.File.Exists(deletePath))
                        System.IO.File.Delete(deletePath);
                }

                if (!Directory.Exists(saveDir))
                    Directory.CreateDirectory(saveDir);

                Estate_VWM.t_Estate.image = Guid.NewGuid().ToString() + Path.GetExtension(Estate_VWM.img_up.FileName);
                string savepath = Path.Combine(Directory.GetCurrentDirectory(), saveDir, Estate_VWM.t_Estate.image);
                using var filestream = new FileStream(savepath, FileMode.Create);
                Estate_VWM.img_up.CopyTo(filestream);
            }

            Estate_VWM.t_Estate.id_category = id_Category;
            _context.T_estate.Update(Estate_VWM.t_Estate);
            await _context.SaveChangesAsync();
            return RedirectToPage("admin");

        }

    }
}
  
