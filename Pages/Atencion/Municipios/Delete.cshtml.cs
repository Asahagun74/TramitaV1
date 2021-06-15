using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebAuthent.Models.Atencion;

namespace WebAuthent.Pages.Atencion
{
    public class DeleteModel : PageModel
    {
        private readonly WebAuthent.Models.Atencion.TRAMITA_DBContext _context;

        public DeleteModel(WebAuthent.Models.Atencion.TRAMITA_DBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CatMunicipio CatMunicipio { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CatMunicipio = await _context.CatMunicipios.FirstOrDefaultAsync(m => m.IdMunicipio == id);

            if (CatMunicipio == null)
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

            CatMunicipio = await _context.CatMunicipios.FindAsync(id);

            if (CatMunicipio != null)
            {
                _context.CatMunicipios.Remove(CatMunicipio);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./AltaMunicipios");
        }
    }
}
