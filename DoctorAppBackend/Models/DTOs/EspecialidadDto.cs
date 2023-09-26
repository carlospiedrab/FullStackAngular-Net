using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs
{
    public class EspecialidadDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="El Nombre es Requerido")]
        [StringLength(60, MinimumLength = 1, ErrorMessage = "El Nombre debe ser Minimo 1 Maximo 60 caracteres")]
        public string NombreEspecialidad { get; set; }

        [Required(ErrorMessage ="La Descripcion es Requerida")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "La Descripcion debe ser Minimo 1 Maximo 100 caracteres")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El estado es Requerido")]
        public int Estado { get; set; }  // 1 - 0
    }
}
