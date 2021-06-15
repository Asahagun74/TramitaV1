using System;
using System.Collections.Generic;

#nullable disable

namespace WebAuthent.Models.Atencion
{
    public partial class CatGrupoEmpledo
    {
        public int IdGpoAtencion { get; set; }
        public int IdEmpleado { get; set; }

        public virtual CatEmpleado IdEmpleadoNavigation { get; set; }
        public virtual CatGruposAtencion IdGpoAtencionNavigation { get; set; }
    }
}
