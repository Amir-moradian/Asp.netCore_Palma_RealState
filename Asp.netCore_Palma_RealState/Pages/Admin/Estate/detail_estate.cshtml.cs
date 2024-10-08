﻿using Asp.netCore_Palma_RealState.Data;
using Asp.netCore_Palma_RealState.Models;
using Asp.netCore_Palma_RealState.Models.ViewModel.EstateViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Asp.netCore_Palma_RealState.Pages.Admin.Estate
{
    public class detail_estateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public detail_estateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        //[BindProperty]
        //public estate_VWM estate_vwm { get; set; }

        //public async Task<IActionResult> OnGet(int id)
        //{
        //    if (id <= 0)
        //    {
        //        return NotFound();
        //    }

        //    estate_vwm.t_Estate = await _context.T_estate
        //        .Include(c => c.t_category)
        //        .FirstOrDefaultAsync(e => e.ID_estate == id);


        //    if (estate_vwm is null)
        //    {
        //        return NotFound();
        //    }


        //    return Page();



        //}

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


    }
}


