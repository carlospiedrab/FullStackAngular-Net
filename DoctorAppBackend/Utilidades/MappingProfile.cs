using AutoMapper;
using Models.DTOs;
using Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilidades
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Especialidad, EspecialidadDto>()
                .ForMember(d => d.Estado, m => m.MapFrom(o => o.Estado == true ? 1 : 0));

            

            CreateMap<Medico, MedicoDto>()
                .ForMember(d => d.Estado, m => m.MapFrom(o => o.Estado == true ? 1 : 0))
                .ForMember(d => d.NombreEspecialidad, m => m.MapFrom(o => o.Especialidad.NombreEspecialidad));

            CreateMap<HistoriaClinica, HistoriaClinicaDto>()
                 .ForMember(d => d.Id, m => m.MapFrom(o => o.Id.ToString()))
                 .ForMember(d => d.Apellidos, m => m.MapFrom(o => o.Paciente.Apellidos))
                 .ForMember(d => d.Nombres, m => m.MapFrom(o => o.Paciente.Nombres))
                 .ForMember(d => d.Direccion, m => m.MapFrom(o => o.Paciente.Direccion))
                 .ForMember(d => d.Telefono, m => m.MapFrom(o => o.Paciente.Telefono))
                 .ForMember(d => d.Genero, m => m.MapFrom(o => o.Paciente.Genero))
                 .ForMember(d => d.Estado, m => m.MapFrom(o => o.Paciente.Estado == true ? 1 : 0));
        }
    }
}
