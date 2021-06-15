using System;
using System.Collections.Generic;

#nullable disable

namespace WebAuthent.Models.Atencion
{
    public partial class CatMunicipio
    {
        public CatMunicipio()
        {
            CatEmpleados = new HashSet<CatEmpleado>();
            CatGrupoMunicipios = new HashSet<CatGrupoMunicipio>();
            CatMunicipioAtencionIdMpioAtencionNavigations = new HashSet<CatMunicipioAtencion>();
            CatMunicipioAtencionIdMunicipioNavigations = new HashSet<CatMunicipioAtencion>();
            CatSedes = new HashSet<CatSede>();
        }

        public int IdMunicipio { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<CatEmpleado> CatEmpleados { get; set; }
        public virtual ICollection<CatGrupoMunicipio> CatGrupoMunicipios { get; set; }
        public virtual ICollection<CatMunicipioAtencion> CatMunicipioAtencionIdMpioAtencionNavigations { get; set; }
        public virtual ICollection<CatMunicipioAtencion> CatMunicipioAtencionIdMunicipioNavigations { get; set; }
        public virtual ICollection<CatSede> CatSedes { get; set; }
    }
}
