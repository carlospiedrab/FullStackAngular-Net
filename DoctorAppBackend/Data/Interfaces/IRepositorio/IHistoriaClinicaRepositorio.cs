using Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces.IRepositorio
{
    public interface IHistoriaClinicaRepositorio : IRepositorioGenerico<HistoriaClinica>
    {
        void Actualizar(HistoriaClinica historiaClinica);
    }
}
