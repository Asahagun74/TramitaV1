using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAuthent.Models.Atencion;
using Microsoft.AspNetCore.Mvc.RazorPages;



namespace WebAuthent.Pages.Atencion.Municipios
{
    public class MunicipiosModel : PageModel
    {

        private readonly WebAuthent.Models.Atencion.TRAMITA_DBContext _context;
        public MunicipiosModel(WebAuthent.Models.Atencion.TRAMITA_DBContext context)
        {
            _context = context;
            CatMunicipioList = new WebAuthent.Pages.Atencion.IndexModel(_context);
            //System.Threading.Tasks.Task task = CatMunicipioList.OnGetMunuicipios();
            CatMunicipioList.OnGetMunuicipios();
            moldelCreate = new WebAuthent.Pages.Atencion.CreateModel(_context);

        }

        public IndexModel CatMunicipioList { get; set; }

        public CreateModel moldelCreate { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }
        [BindProperty]
        public CatMunicipio CatMunicipio { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.CatMunicipios.Add(CatMunicipio);
            await _context.SaveChangesAsync();

            return RedirectToPage("./AltaMunicipios");
        }
    }
}
