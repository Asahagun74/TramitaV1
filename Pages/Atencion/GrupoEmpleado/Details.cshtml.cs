using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebAuthent.Models.Atencion;

namespace WebAuthent.Pages.Atencion.GrupoEmpleado
{
    public class DetailsModel : PageModel
    {
        private readonly WebAuthent.Models.Atencion.TRAMITA_DBContext _context;

        public DetailsModel(WebAuthent.Models.Atencion.TRAMITA_DBContext context)
        {
            _context = context;
        }

        public CatGrupoEmpledo CatGrupoEmpledo { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CatGrupoEmpledo = await _context.CatGrupoEmpledos
                .Include(c => c.IdEmpleadoNavigation)
                .Include(c => c.IdGpoAtencionNavigation).FirstOrDefaultAsync(m => m.IdGpoAtencion == id);

            if (CatGrupoEmpledo == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
