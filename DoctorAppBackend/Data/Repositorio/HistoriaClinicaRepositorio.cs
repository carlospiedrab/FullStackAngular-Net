using Data.Interfaces.IRepositorio;
using Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositorio
{
    public class HistoriaClinicaRepositorio : Repositorio<HistoriaClinica>, IHistoriaClinicaRepositorio
    {

        private readonly ApplicationDbContext _db;

        public HistoriaClinicaRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Actualizar(HistoriaClinica historiaClinica)
        {
            var historiaClinicaDb = _db.HistoriasClinicas.FirstOrDefault(e => e.Id == historiaClinica.Id);
            if(historiaClinicaDb != null)
            {

                historiaClinicaDb.FechaActualizacion = DateTime.Now;
               
                _db.SaveChanges();
            }

        }
    }
}
