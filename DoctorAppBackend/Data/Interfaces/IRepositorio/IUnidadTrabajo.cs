﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces.IRepositorio
{
    public interface IUnidadTrabajo : IDisposable
    {
        IEspecialidadRepositorio Especialidad { get; }

        Task Guardar();
    }
}
