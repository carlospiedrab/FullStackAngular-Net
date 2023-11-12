using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entidades
{
    public class RolAplicacion : IdentityRole<int>
    {
        public ICollection<RolUsuarioAplicacion> RolUsuarios { get; set; }
    }
}
