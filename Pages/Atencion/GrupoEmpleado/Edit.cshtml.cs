using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAuthent.Models.Atencion;

namespace WebAuthent.Pages.Atencion.GrupoEmpleado
{
    public class EditModel : PageModel
    {
        private readonly WebAuthent.Models.Atencion.TRAMITA_DBContext _context;

        public EditModel(WebAuthent.Models.Atencion.TRAMITA_DBContext context)
        {
            _context = context;
        }

        [BindProperty]
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
           ViewData["IdEmpleado"] = new SelectList(_context.CatEmpleados, "IdEmpleado", "IdEmpleado");
           ViewData["IdGpoAtencion"] = new SelectList(_context.CatGruposAtencions, "IdGpoAtencion", "IdGpoAtencion");
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

            _context.Attach(CatGrupoEmpledo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CatGrupoEmpledoExists(CatGrupoEmpledo.IdGpoAtencion))
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

        private bool CatGrupoEmpledoExists(int id)
        {
            return _context.CatGrupoEmpledos.Any(e => e.IdGpoAtencion == id);
        }
    }
}
