using System;
using System.Collections.Generic;

namespace DemoEFEngReversaMvc.Models
{
    public partial class Administradore
    {
        public decimal CodAdministrador { get; set; }
        public decimal NivelPrivilegio { get; set; }

        public virtual Usuario CodAdministradorNavigation { get; set; } = null!;
    }
}
