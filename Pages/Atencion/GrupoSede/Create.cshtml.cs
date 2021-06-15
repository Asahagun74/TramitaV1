using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebAuthent.Models.Atencion;

namespace WebAuthent.Pages.Atencion.GrupoSede
{
    public class CreateModel : PageModel
    {
        private readonly WebAuthent.Models.Atencion.TRAMITA_DBContext _context;

        public CreateModel(WebAuthent.Models.Atencion.TRAMITA_DBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["IdGpoAtencion"] = new SelectList(_context.CatGruposAtencions, "IdGpoAtencion", "Nombre");
        ViewData["IdSede"] = new SelectList(_context.CatSedes, "IdSede", "Nombre");
            return Page();
        }

        [BindProperty]
        public CatGruposSede CatGruposSede { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.CatGruposSedes.Add(CatGruposSede);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
