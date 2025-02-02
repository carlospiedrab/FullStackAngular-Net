using Data.Interfaces.IRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositorio
{
    public class UnidadTrabajo : IUnidadTrabajo
    {
        private readonly ApplicationDbContext _db;
        public IEspecialidadRepositorio Especialidad { get; private set; }
        public IMedicoRepositorio Medico { get; private set; }
        public IPacienteRepositorio Paciente { get; private set; }
        public IHistoriaClinicaRepositorio HistoriaClinica { get; private set; }
        public IAntecedenteRepositorio Antecedente { get; private set; }

        public UnidadTrabajo(ApplicationDbContext db)
        {
            _db = db;
            Especialidad = new EspecialidadRepositorio(db);
            Medico = new MedicoRepositorio(db);
            Paciente = new PacienteRepositorio(db);
            HistoriaClinica = new HistoriaClinicaRepositorio(db);
            Antecedente = new AntecedenteRepositorio(db);
        }

        public void Dispose()
        {
            _db.Dispose();
        }
        public async Task Guardar()
        {
            await _db.SaveChangesAsync();
        }
    }
}
