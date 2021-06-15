using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebAuthent.Models.Atencion;

namespace WebAuthent.Pages.Atencion.mpioAtencion
{
    public class DeleteModel : PageModel
    {
        private readonly WebAuthent.Models.Atencion.TRAMITA_DBContext _context;

        public DeleteModel(WebAuthent.Models.Atencion.TRAMITA_DBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CatMunicipioAtencion CatMunicipioAtencion { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CatMunicipioAtencion = await _context.CatMunicipioAtencions
                .Include(c => c.IdMunicipioNavigation).FirstOrDefaultAsync(m => m.IdMpioAtencion == id);

            if (CatMunicipioAtencion == null)
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

            CatMunicipioAtencion = await _context.CatMunicipioAtencions.FindAsync(id);

            if (CatMunicipioAtencion != null)
            {
                _context.CatMunicipioAtencions.Remove(CatMunicipioAtencion);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
