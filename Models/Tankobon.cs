using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace tcc1_api.Models
{
    public class Tankobon
    {
        public int Id { get; set; }
        // public string EdicaoNumero { get; set; } = string.Empty;
        // public DateTime EdicaoDataLancamento { get; set; }
        // public string EdicaoSerieNomeInter { get; set; } = string.Empty;
        // public int EdicaoSerieCicloNum { get; set; }
        public int EdicaoId { get; set; }
        public Edicao? Edicao { get; set; }
        public int NumeroCapitulos { get; set; }
    }

    public class TankobonConfiguration : IEntityTypeConfiguration<Tankobon>
    {
        public void Configure(EntityTypeBuilder<Tankobon> builder)
        {
            // builder.HasKey(e => new { e.EdicaoNumero, e.EdicaoDataLancamento, e.EdicaoSerieNomeInter, e.EdicaoSerieCicloNum });
            builder.HasIndex(e => new { e.EdicaoId }).IsUnique();
            // builder.ToTable("Tankobons");
        }
    }
}