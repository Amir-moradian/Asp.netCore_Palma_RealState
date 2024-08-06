using Asp.netCore_Palma_RealState.Data;
using Asp.netCore_Palma_RealState.Models;
using Asp.netCore_Palma_RealState.Models.ViewModel.EstateViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Asp.netCore_Palma_RealState.Pages.Admin.Estate
{
    public class add_estateModel : PageModel
    {
        private ApplicationDbContext _context;

        public add_estateModel(ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public add_estate_VWM? Estate_VWM { get; set; }

        public void OnGet()
        {
            init_category();
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

        public async Task<IActionResult> OnPost()
        {

            //(!ModelState.IsValid && Estate_VWM.select_category == null)
            // (!ModelState.IsValid && Estate_VWM.select_category is null)

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
                if (!Directory.Exists(saveDir))
                    Directory.CreateDirectory(saveDir);

                Estate_VWM.t_Estate.image = Guid.NewGuid().ToString() + Path.GetExtension(Estate_VWM.img_up.FileName);
                string savepath = Path.Combine(Directory.GetCurrentDirectory(), saveDir, Estate_VWM.t_Estate.image);
                using var filestream = new FileStream(savepath, FileMode.Create);
                Estate_VWM.img_up.CopyTo(filestream);
            }

            Estate_VWM.t_Estate.id_category = id_Category;
            await _context.T_estate.AddAsync(Estate_VWM.t_Estate);
            await _context.SaveChangesAsync();
            return RedirectToPage("admin");



        }
    }
}
