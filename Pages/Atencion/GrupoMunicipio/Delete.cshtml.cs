using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebAuthent.Models.Atencion;

namespace WebAuthent.Pages.Atencion.GrupoMunicipio
{
    public class DeleteModel : PageModel
    {
        private readonly WebAuthent.Models.Atencion.TRAMITA_DBContext _context;

        public DeleteModel(WebAuthent.Models.Atencion.TRAMITA_DBContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CatGrupoMunicipio = await _context.CatGrupoMunicipios.FindAsync(id);

            if (CatGrupoMunicipio != null)
            {
                _context.CatGrupoMunicipios.Remove(CatGrupoMunicipio);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
