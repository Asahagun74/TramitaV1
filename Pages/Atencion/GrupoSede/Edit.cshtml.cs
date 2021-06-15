using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAuthent.Models.Atencion;

namespace WebAuthent.Pages.Atencion.GrupoSede
{
    public class EditModel : PageModel
    {
        private readonly WebAuthent.Models.Atencion.TRAMITA_DBContext _context;

        public EditModel(WebAuthent.Models.Atencion.TRAMITA_DBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CatGruposSede CatGruposSede { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CatGruposSede = await _context.CatGruposSedes
                .Include(c => c.IdGpoAtencionNavigation)
                .Include(c => c.IdSedeNavigation).FirstOrDefaultAsync(m => m.IdGpoAtencion == id);

            if (CatGruposSede == null)
            {
                return NotFound();
            }
           ViewData["IdGpoAtencion"] = new SelectList(_context.CatGruposAtencions, "IdGpoAtencion", "IdGpoAtencion");
           ViewData["IdSede"] = new SelectList(_context.CatSedes, "IdSede", "IdSede");
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

            _context.Attach(CatGruposSede).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CatGruposSedeExists(CatGruposSede.IdGpoAtencion))
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

        private bool CatGruposSedeExists(int id)
        {
            return _context.CatGruposSedes.Any(e => e.IdGpoAtencion == id);
        }
    }
}
