using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configuraciones
{
    public class HistoriaClinicaConfiguracion : IEntityTypeConfiguration<HistoriaClinica>
    {

        public void Configure(EntityTypeBuilder<HistoriaClinica> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.PacienteId).IsRequired();

            /* Relaciones */

            builder.HasOne(x => x.Paciente).WithOne(x => x.HistoriaClinica)
                   .HasForeignKey<HistoriaClinica>(x => x.PacienteId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
