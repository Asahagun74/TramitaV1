using System;
using System.Collections.Generic;

#nullable disable

namespace WebAuthent.Models.Atencion
{
    public partial class CatGruposSede
    {
        public int IdGpoAtencion { get; set; }
        public int IdSede { get; set; }

        public virtual CatGruposAtencion IdGpoAtencionNavigation { get; set; }
        public virtual CatSede IdSedeNavigation { get; set; }
    }
}
