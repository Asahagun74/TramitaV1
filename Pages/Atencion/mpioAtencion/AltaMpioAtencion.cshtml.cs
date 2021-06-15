using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebAuthent.Pages.Atencion.mpioAtencion
{
    public class AltaMpioAtencion : PageModel
    {
        private readonly WebAuthent.Models.Atencion.TRAMITA_DBContext _context;
        public AltaMpioAtencion(WebAuthent.Models.Atencion.TRAMITA_DBContext context)
        {
            _context = context;
            mCreate = new CreateModel(_context);

            //System.Threading.Tasks.Task task = CatMunicipioList.OnGetMunuicipios();
            //CatMunicipioList.OnGetMunuicipios();
            mDetail = new DetailsModel(_context);
            mDetail.OnGetMunuicipiosAtencion();

        }
        public IActionResult OnGet()
        {
            ViewData["IdMunicipio"] = new SelectList(_context.CatMunicipios, "IdMunicipio", "Nombre");
            return Page(); 
        }
        public CreateModel mCreate { get; set; }
        public DetailsModel mDetail { get; set; }
        
    }
}
