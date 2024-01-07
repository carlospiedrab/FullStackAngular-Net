using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs
{
    public class UsuarioListaDto
    {
        public string Username { get; set; }
        public string Apellidos { get; set; }
        public string Nombres { get; set; }
        public string Email { get; set; }
        public string Rol { get; set; }
    }
}
