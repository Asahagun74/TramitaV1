using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebAuthent.Models.Atencion;

namespace WebAuthent.Pages.Atencion.GrupoEmpleado
{
    public class IndexModel : PageModel
    {
        private readonly WebAuthent.Models.Atencion.TRAMITA_DBContext _context;

        public IndexModel(WebAuthent.Models.Atencion.TRAMITA_DBContext context)
        {
            _context = context;
        }

        public IList<CatGrupoEmpledo> CatGrupoEmpledo { get;set; }

        public async Task OnGetAsync()
        {
            CatGrupoEmpledo = await _context.CatGrupoEmpledos
                .Include(c => c.IdEmpleadoNavigation)
                .Include(c => c.IdGpoAtencionNavigation).ToListAsync();
        }
    }
}
