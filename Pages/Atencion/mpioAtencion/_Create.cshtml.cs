﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebAuthent.Models.Atencion;

namespace WebAuthent.Pages.Atencion.mpioAtencion
{
    public class CreateModel : PageModel
    {
        private readonly WebAuthent.Models.Atencion.TRAMITA_DBContext _context;

        public CreateModel(WebAuthent.Models.Atencion.TRAMITA_DBContext context)
        {
            _context = context;
        }
        public IList<CatMunicipio> CatMunicipio { get; set; }

        
        public IActionResult OnGet()
        {
            ViewData["IdMunicipio"] = new SelectList(_context.CatMunicipios, "IdMunicipio", "Nombre");
            return Page();
        }

        [BindProperty]
        public CatMunicipioAtencion CatMunicipioAtencion { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.CatMunicipioAtencions.Add(CatMunicipioAtencion);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
