using System;
using System.Collections.Generic;

#nullable disable

namespace WebAuthent.Models.Atencion
{
    public partial class CatGruposAtencion
    {
        public CatGruposAtencion()
        {
            CatGrupoEmpledos = new HashSet<CatGrupoEmpledo>();
            CatGrupoMunicipios = new HashSet<CatGrupoMunicipio>();
            CatGruposSedes = new HashSet<CatGruposSede>();
        }

        public int IdGpoAtencion { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<CatGrupoEmpledo> CatGrupoEmpledos { get; set; }
        public virtual ICollection<CatGrupoMunicipio> CatGrupoMunicipios { get; set; }
        public virtual ICollection<CatGruposSede> CatGruposSedes { get; set; }
    }
}
