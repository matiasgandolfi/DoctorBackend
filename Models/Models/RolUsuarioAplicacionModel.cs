using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class RolUsuarioAplicacionModel : IdentityUserRole<int>
    {
        public UsuarioAplicacionModel UsuarioAplicacion{ get; set; }
        public RolAplicacionModel RolAplicacion { get; set; }
    }
}
