using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAuthent.Models.Atencion;

namespace WebAuthent.Pages.Atencion.mpioAtencion
{
    public class EditModel : PageModel
    {
        private readonly WebAuthent.Models.Atencion.TRAMITA_DBContext _context;

        public EditModel(WebAuthent.Models.Atencion.TRAMITA_DBContext context)
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

            _context.Attach(CatMunicipioAtencion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CatMunicipioAtencionExists(CatMunicipioAtencion.IdMpioAtencion))
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

        private bool CatMunicipioAtencionExists(int id)
        {
            return _context.CatMunicipioAtencions.Any(e => e.IdMpioAtencion == id);
        }
    }
}
