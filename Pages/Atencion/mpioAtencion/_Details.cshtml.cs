using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebAuthent.Models.Atencion;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebAuthent.Pages.Atencion.mpioAtencion
{
    public class DetailsModel : PageModel
    {
        private readonly WebAuthent.Models.Atencion.TRAMITA_DBContext _context;

        public DetailsModel(WebAuthent.Models.Atencion.TRAMITA_DBContext context)
        {
            _context = context;
        }

        public IList<CatMunicipioAtencion> CatMunicipioAtencion { get; set; }

        public void OnGetMunuicipiosAtencion()
        {
            CatMunicipioAtencion =  _context.CatMunicipioAtencions
                //.Where(s => s.IdMpioAtencionNavigation.IdMunicipio == 6)
               .Include(c => c.IdMunicipioNavigation)
               .Include(c => c.IdMpioAtencionNavigation).ToList();
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
           
                        
            CatMunicipioAtencion = await _context.CatMunicipioAtencions
                .Where(s => s.IdMpioAtencionNavigation.IdMunicipio == id)
               .Include(c => c.IdMunicipioNavigation)
               .Include(c => c.IdMpioAtencionNavigation).ToListAsync();


            if (CatMunicipioAtencion == null)
            {
                return NotFound();
            }
            
            return Page();
        }
    }
}
