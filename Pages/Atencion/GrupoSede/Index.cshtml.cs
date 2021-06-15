using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebAuthent.Models.Atencion;

namespace WebAuthent.Pages.Atencion.GrupoSede
{
    public class IndexModel : PageModel
    {
        private readonly WebAuthent.Models.Atencion.TRAMITA_DBContext _context;

        public IndexModel(WebAuthent.Models.Atencion.TRAMITA_DBContext context)
        {
            _context = context;
        }

        public IList<CatGruposSede> CatGruposSede { get; set; }

        public async Task OnGetAsync()
        {
            /*CatGruposSede = await _context.CatGruposSedes
                .Include(c => c.IdGpoAtencionNavigation)
                .Include(c => c.IdSedeNavigation).ToListAsync();*/

            CatGruposSede = await _context.CatGruposSedes
                .Include(c => c.IdGpoAtencionNavigation)
                .Include(c => c.IdSedeNavigation.IdMunicipioNavigation)
                .Include(c => c.IdSedeNavigation).ToListAsync();

        }
    }
    
}
