using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAuthent.Models.Atencion;

namespace WebAuthent.Pages.Atencion.GrupoMunicipio
{
    public class EditModel : PageModel
    {
        private readonly WebAuthent.Models.Atencion.TRAMITA_DBContext _context;

        public EditModel(WebAuthent.Models.Atencion.TRAMITA_DBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CatGrupoMunicipio CatGrupoMunicipio { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CatGrupoMunicipio = await _context.CatGrupoMunicipios
                .Include(c => c.IdGpoAtencionNavigation)
                .Include(c => c.IdMunicipioNavigation).FirstOrDefaultAsync(m => m.IdGpoAtencion == id);

            if (CatGrupoMunicipio == null)
            {
                return NotFound();
            }
           ViewData["IdGpoAtencion"] = new SelectList(_context.CatGruposAtencions, "IdGpoAtencion", "IdGpoAtencion");
           ViewData["IdMunicipio"] = new SelectList(_context.CatMunicipios, "IdMunicipio", "IdMunicipio");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(CatGrupoMunicipio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CatGrupoMunicipioExists(CatGrupoMunicipio.IdGpoAtencion))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CatGrupoMunicipioExists(int id)
        {
            return _context.CatGrupoMunicipios.Any(e => e.IdGpoAtencion == id);
        }
    }
}
