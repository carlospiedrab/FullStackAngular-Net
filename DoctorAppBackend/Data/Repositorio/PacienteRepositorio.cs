using Data.Interfaces.IRepositorio;
using Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositorio
{
    public class PacienteRepositorio : Repositorio<Paciente>, IPacienteRepositorio
    {

        private readonly ApplicationDbContext _db;

        public PacienteRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Actualizar(Paciente paciente)
        {
            var pacienteDb = _db.Pacientes.FirstOrDefault(e => e.Id == paciente.Id);
            if(pacienteDb != null)
            {
                pacienteDb.Apellidos = paciente.Apellidos;
                pacienteDb.Nombres = paciente.Nombres;
                pacienteDb.Estado = paciente.Estado;
                pacienteDb.FechaActualizacion = DateTime.Now;
                pacienteDb.Telefono = paciente.Telefono;
                pacienteDb.Genero = paciente.Genero;
                pacienteDb.ActualizadoPorId = paciente.ActualizadoPorId;
                pacienteDb.Direccion = paciente.Direccion;
                _db.SaveChanges();
            }

        }
    }
}
