using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebAuthent.Models.Atencion;

namespace WebAuthent.Pages.Atencion.Empleados
{
    public class DetailsModel : PageModel
    {
        private readonly WebAuthent.Models.Atencion.TRAMITA_DBContext _context;

        public DetailsModel(WebAuthent.Models.Atencion.TRAMITA_DBContext context)
        {
            _context = context;
        }

        public CatEmpleado CatEmpleado { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CatEmpleado = await _context.CatEmpleados
                .Include(c => c.IdMunicipioNavigation)
                .Include(c => c.IdSedeNavigation).FirstOrDefaultAsync(m => m.IdEmpleado == id);

            if (CatEmpleado == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
