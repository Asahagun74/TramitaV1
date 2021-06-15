using System;
using System.Collections.Generic;

#nullable disable

namespace WebAuthent.Models.Atencion
{
    public partial class CatGrupoMunicipio
    {
        public int IdGpoAtencion { get; set; }
        public int IdMunicipio { get; set; }

        public virtual CatGruposAtencion IdGpoAtencionNavigation { get; set; }
        public virtual CatMunicipio IdMunicipioNavigation { get; set; }
    }
}
