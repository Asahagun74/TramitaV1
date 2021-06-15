using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAuthent.Models.Atencion;

namespace WebAuthent.Pages.Atencion.Empleados
{
    public class EditModel : PageModel
    {
        private readonly WebAuthent.Models.Atencion.TRAMITA_DBContext _context;

        public EditModel(WebAuthent.Models.Atencion.TRAMITA_DBContext context)
        {
            _context = context;
        }

        [BindProperty]
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
           ViewData["IdMunicipio"] = new SelectList(_context.CatMunicipios, "IdMunicipio", "IdMunicipio");
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

            _context.Attach(CatEmpleado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CatEmpleadoExists(CatEmpleado.IdEmpleado))
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

        private bool CatEmpleadoExists(int id)
        {
            return _context.CatEmpleados.Any(e => e.IdEmpleado == id);
        }
    }
}
