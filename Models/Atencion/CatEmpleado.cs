using System;
using System.Collections.Generic;

#nullable disable

namespace WebAuthent.Models.Atencion
{
    public partial class CatEmpleado
    {
        public CatEmpleado()
        {
            CatGrupoEmpledos = new HashSet<CatGrupoEmpledo>();
        }

        public int IdEmpleado { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public int? IdMunicipio { get; set; }
        public int? IdSede { get; set; }
        public string Usuario { get; set; }
        public string Contraseña { get; set; }

        public virtual CatMunicipio IdMunicipioNavigation { get; set; }
        public virtual CatSede IdSedeNavigation { get; set; }
        public virtual ICollection<CatGrupoEmpledo> CatGrupoEmpledos { get; set; }
    }
}
