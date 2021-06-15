using System;
using System.Collections.Generic;

#nullable disable

namespace WebAuthent.Models.Atencion
{
    public partial class CatMunicipioAtencion
    {
        public int IdMpioAtencion { get; set; }
        public int IdMunicipio { get; set; }

        public virtual CatMunicipio IdMpioAtencionNavigation { get; set; }
        public virtual CatMunicipio IdMunicipioNavigation { get; set; }
        
    }
}
