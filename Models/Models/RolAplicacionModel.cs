using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class RolAplicacionModel : IdentityRole<int>
    {
        public ICollection<RolUsuarioAplicacionModel> RolUsuarios { get; set; }
    }
}
