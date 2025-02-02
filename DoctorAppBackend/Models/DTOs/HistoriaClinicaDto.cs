﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models.DTOs
{
    public class HistoriaClinicaDto
    {
        public string Id { get; set; }
        public int PacienteId { get; set; }

        [Required(ErrorMessage ="Apellidos es Requerido")]
        [StringLength(60, MinimumLength = 1, ErrorMessage ="Apellidos debe ser Minimo 1 y Maximo 60 caracteres")]
        public string Apellidos { get; set; }

        [Required(ErrorMessage = "Nombres es Requerido")]
        [StringLength(60, MinimumLength = 1, ErrorMessage = "Nombres debe ser Minimo 1 y Maximo 60 caracteres")]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "Direccion es Requerido")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Direccion debe ser Minimo 1 y Maximo 100 caracteres")]
        public string Direccion { get; set; }

        [StringLength(40, MinimumLength = 1, ErrorMessage = "Telefono debe ser Minimo 1 y Maximo 40 caracteres")]
        public string Telefono { get; set; }

        [Required(ErrorMessage ="Genero es requerido")]
        public char Genero { get; set; }

        public int Estado { get; set; }

        [JsonIgnore]
        public string UserName { get; set; }

        public List<string> Observaciones { get; set; }
    }
}
