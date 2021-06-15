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
    public class DetailsModel : PageModel
    {
        private readonly WebAuthent.Models.Atencion.TRAMITA_DBContext _context;

        public DetailsModel(WebAuthent.Models.Atencion.TRAMITA_DBContext context)
        {
            _context = context;
        }

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
    }
}
