using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace tcc1_api.Models
{
    public class Contribui
    {
        public int ContribuidorId { get; set; }
        public Contribuidor? Contribuidor { get; set; }

        public int EdicaoId { get; set; }
        public Edicao? Edicao { get; set; }

        public string Funcao { get; set; } = string.Empty;
    }

    public class ContribuiConfiguration : IEntityTypeConfiguration<Contribui>
    {
        public void Configure(EntityTypeBuilder<Contribui> builder)
        {
            builder.HasKey(e => new { e.ContribuidorId, e.EdicaoId, e.Funcao });
            builder.HasOne(e => e.Contribuidor).WithMany(e => e.Contribuicoes).HasForeignKey(p => p.ContribuidorId);
            builder.HasOne(e => e.Edicao).WithMany(e => e.Contribuicoes).HasForeignKey(p => p.EdicaoId);
        }
    }
}