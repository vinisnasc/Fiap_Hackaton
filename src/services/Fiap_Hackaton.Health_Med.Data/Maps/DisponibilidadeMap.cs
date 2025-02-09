using Fiap_Hackaton.Health_Med.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap_Hackaton.Health_Med.Data.Maps
{
    public class DisponibilidadeMap : IEntityTypeConfiguration<Disponibilidade>
    {
        public void Configure(EntityTypeBuilder<Disponibilidade> builder)
        {
            builder.ToTable("Disponibilidades");

            builder.Property(d => d.ValorConsulta)
                .HasColumnType("decimal(18,2)");

        }
    }
}
