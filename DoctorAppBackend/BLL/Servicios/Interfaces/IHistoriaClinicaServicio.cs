using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Servicios.Interfaces
{
    public interface IHistoriaClinicaServicio
    {
        Task<IEnumerable<HistoriaClinicaDto>> ObtenerTodos();
        Task<HistoriaClinicaDto> Agregar(HistoriaClinicaDto modelDto);
    }
}
