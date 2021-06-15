using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebAuthent.Models.Atencion;

namespace WebAuthent.Pages.Atencion.GrupoSede
{
    public class DeleteModel : PageModel
    {
        private readonly WebAuthent.Models.Atencion.TRAMITA_DBContext _context;

        public DeleteModel(WebAuthent.Models.Atencion.TRAMITA_DBContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CatGruposSede = await _context.CatGruposSedes.FindAsync(id);

            if (CatGruposSede != null)
            {
                _context.CatGruposSedes.Remove(CatGruposSede);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
