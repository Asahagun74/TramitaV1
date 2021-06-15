using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebAuthent.Models.Atencion;

namespace WebAuthent.Pages.Atencion.GrupoEmpleado
{
    public class CreateModel : PageModel
    {
        private readonly WebAuthent.Models.Atencion.TRAMITA_DBContext _context;

        public CreateModel(WebAuthent.Models.Atencion.TRAMITA_DBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["IdEmpleado"] = new SelectList(_context.CatEmpleados, "IdEmpleado", "Nombre");
        ViewData["IdGpoAtencion"] = new SelectList(_context.CatGruposAtencions, "IdGpoAtencion", "Nombre");
            return Page();
        }

        [BindProperty]
        public CatGrupoEmpledo CatGrupoEmpledo { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.CatGrupoEmpledos.Add(CatGrupoEmpledo);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
