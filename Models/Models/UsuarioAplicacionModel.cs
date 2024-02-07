using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class UsuarioAplicacionModel : IdentityUser<int>
    {
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public ICollection<RolUsuarioAplicacionModel> RolUsuarios { get; set; }
    }
}
