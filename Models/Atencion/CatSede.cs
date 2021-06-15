using System;
using System.Collections.Generic;

#nullable disable

namespace WebAuthent.Models.Atencion
{
    public partial class CatSede
    {
        public CatSede()
        {
            CatEmpleados = new HashSet<CatEmpleado>();
            CatGruposSedes = new HashSet<CatGruposSede>();
        }

        public int IdSede { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Responsable { get; set; }
        public int? IdMunicipio { get; set; }

        public virtual CatMunicipio IdMunicipioNavigation { get; set; }
        public virtual ICollection<CatEmpleado> CatEmpleados { get; set; }
        public virtual ICollection<CatGruposSede> CatGruposSedes { get; set; }
    }
}
