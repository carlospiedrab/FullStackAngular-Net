using AutoMapper;
using BLL.Servicios.Interfaces;
using Data.Interfaces.IRepositorio;
using Models.DTOs;
using Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Servicios
{
    public class EspecialidadServicio : IEspecialidadServicio
    {

        private readonly IUnidadTrabajo _unidadTrabajo;
        private readonly IMapper _mapper;

        public EspecialidadServicio(IUnidadTrabajo unidadTrabajo, IMapper mapper)
        {
            _unidadTrabajo = unidadTrabajo;
            _mapper = mapper;
        }

        public async Task<EspecialidadDto> Agregar(EspecialidadDto modeloDto)
        {
            try
            {
                Especialidad especialidad = new Especialidad
                {
                    NombreEspecialidad = modeloDto.NombreEspecialidad,
                    Descripcion = modeloDto.Descripcion,
                    Estado = modeloDto.Estado == 1 ? true : false,
                    FechaCreacion = DateTime.Now,
                    FechaActualizacion = DateTime.Now
                };
                await _unidadTrabajo.Especialidad.Agregar(especialidad);
                await _unidadTrabajo.Guardar();
                if (especialidad.Id == 0)
                    throw new TaskCanceledException("La especialidad no se pudo crear");
                return _mapper.Map<EspecialidadDto>(especialidad);
            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task Actualizar(EspecialidadDto modeloDto)
        {
            try
            {
                var especialidadDb = await _unidadTrabajo.Especialidad.ObtenerPrimero(e => e.Id == modeloDto.Id);
                if (especialidadDb == null)
                    throw new TaskCanceledException("La especialidad no existe");

                especialidadDb.NombreEspecialidad = modeloDto.NombreEspecialidad;
                especialidadDb.Descripcion = modeloDto.Descripcion;
                especialidadDb.Estado = modeloDto.Estado == 1 ? true : false;
                _unidadTrabajo.Especialidad.Actualizar(especialidadDb);
                await _unidadTrabajo.Guardar();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task Remover(int id)
        {
            try
            {
                var especialidadDb = await _unidadTrabajo.Especialidad.ObtenerPrimero(e => e.Id == id);
                if (especialidadDb == null)
                    throw new TaskCanceledException("La especialidad no existe");
                _unidadTrabajo.Especialidad.Remover(especialidadDb);
                await _unidadTrabajo.Guardar();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<EspecialidadDto>> ObtenerTodos()
        {
            try
            {
                var lista = await _unidadTrabajo.Especialidad.ObtenerTodos(
                                    orderBy: e => e.OrderBy(e => e.NombreEspecialidad));
                return _mapper.Map<IEnumerable<EspecialidadDto>>(lista);
            }
            catch (Exception)
            {

                throw;
            }
        }

      
    }
}
