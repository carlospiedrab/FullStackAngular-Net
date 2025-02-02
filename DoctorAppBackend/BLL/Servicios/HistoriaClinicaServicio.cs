using AutoMapper;
using BLL.Servicios.Interfaces;
using Data;
using Data.Interfaces.IRepositorio;
using Microsoft.EntityFrameworkCore;
using Models.DTOs;
using Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Servicios
{
    public class HistoriaClinicaServicio : IHistoriaClinicaServicio
    {

        private readonly IUnidadTrabajo _unidadTrabajo;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _dbContext;

        public HistoriaClinicaServicio(IUnidadTrabajo unidadTrabajo, IMapper mapper, ApplicationDbContext dbContext)
        {
            _unidadTrabajo = unidadTrabajo;
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<HistoriaClinicaDto> Agregar(HistoriaClinicaDto modelDto)
        {
            Paciente paciente;
            HistoriaClinica historiaClinica;
            var appUser = await _dbContext.UsuarioAplicacion.FirstOrDefaultAsync
                                            (u => u.UserName == modelDto.UserName);
            if (appUser == null)
                throw new TaskCanceledException("El usuario no Existe");

            try
            {
                paciente = new Paciente
                {
                    Apellidos = modelDto.Apellidos,
                    Nombres = modelDto.Nombres,
                    Direccion = modelDto.Direccion,
                    Telefono = modelDto.Telefono,
                    Genero = modelDto.Genero,
                    Estado = modelDto.Estado == 1 ? true : false,
                    FechaCreacion = DateTime.Now,
                    FechaActualizacion = DateTime.Now,
                    CreadoPorId = appUser.Id,
                    ActualizadoPorId = appUser.Id
                };
                await _unidadTrabajo.Paciente.Agregar(paciente);
                await _unidadTrabajo.Guardar();
            }
            catch (Exception)
            {

                throw;
            }

            try
            {
                historiaClinica = new HistoriaClinica
                {
                    PacienteId = paciente.Id,
                    FechaCreacion = DateTime.Now,
                    FechaActualizacion = DateTime.Now
                };
                await _unidadTrabajo.HistoriaClinica.Agregar(historiaClinica);
                await _unidadTrabajo.Guardar();
            }
            catch (Exception)
            {

                throw;
            }

            foreach (var observacion in modelDto.Observaciones)
            {
                try
                {
                    Antecedente antecedente = new Antecedente
                    {
                        HistoriaClinicaId = historiaClinica.Id,
                        Observacion = observacion,
                        FechaCreacion = DateTime.Now,
                        FechaActualizacion = DateTime.Now
                    };
                    await _unidadTrabajo.Antecedente.Agregar(antecedente);
                    await _unidadTrabajo.Guardar();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return _mapper.Map<HistoriaClinicaDto>(historiaClinica);

        }

        public async Task<IEnumerable<HistoriaClinicaDto>> ObtenerTodos()
        {
            try
            {
                IEnumerable<HistoriaClinica> lista = await _unidadTrabajo.HistoriaClinica.ObtenerTodos
                                                            (incluirPropiedades: "Paciente",
                                                            orderBy: e => e.OrderBy(e => e.Paciente.Apellidos));
                IEnumerable<HistoriaClinicaDto> listaDto = _mapper.Map<IEnumerable<HistoriaClinicaDto>>(lista);
                foreach (var item in listaDto)
                {
                    IEnumerable<Antecedente> antecedentes = await _unidadTrabajo.Antecedente.ObtenerTodos
                                                             (a => a.HistoriaClinicaId == Guid.Parse(item.Id));
                    item.Observaciones = antecedentes.Select(a => a.Observacion).ToList();
                }
                return listaDto;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
