using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebAuthent.Models.Atencion;

namespace WebAuthent.Pages.Atencion.GrupoMunicipio
{
    public class IndexModel : PageModel
    {
        private readonly WebAuthent.Models.Atencion.TRAMITA_DBContext _context;

        public IndexModel(WebAuthent.Models.Atencion.TRAMITA_DBContext context)
        {
            _context = context;
        }

        public IList<CatGrupoMunicipio> CatGrupoMunicipio { get;set; }

        public async Task OnGetAsync()
        {
            CatGrupoMunicipio = await _context.CatGrupoMunicipios
                .Include(c => c.IdGpoAtencionNavigation)
                .Include(c => c.IdMunicipioNavigation).ToListAsync();
        }
    }
}
