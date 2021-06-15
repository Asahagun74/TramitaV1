using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebAuthent.Models.Atencion;

namespace WebAuthent.Pages.Atencion.Sedes
{
    public class DeleteModel : PageModel
    {
        private readonly WebAuthent.Models.Atencion.TRAMITA_DBContext _context;

        public DeleteModel(WebAuthent.Models.Atencion.TRAMITA_DBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CatSede CatSede { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CatSede = await _context.CatSedes
                .Include(c => c.IdMunicipioNavigation).FirstOrDefaultAsync(m => m.IdSede == id);

            if (CatSede == null)
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

            CatSede = await _context.CatSedes.FindAsync(id);

            if (CatSede != null)
            {
                _context.CatSedes.Remove(CatSede);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
