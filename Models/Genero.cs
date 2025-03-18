using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace tcc1_api.Models
{
    public class Genero
    {
        public int Id { get; set; }
        public string Tipo { get; set; } = string.Empty;
        // public string SerieNomeInter { get; set; } = string.Empty;
        // public int SerieCicloNum { get; set; }
        public int SerieId { get; set; }
        public Serie? Serie { get; set; }
    }

    public class GeneroConfiguration : IEntityTypeConfiguration<Genero>
    {
        public void Configure(EntityTypeBuilder<Genero> builder)
        {
            // builder.HasKey(e => new { e.Tipo, e.SerieNomeInter, e.SerieCicloNum });
            builder.HasIndex(e => new { e.Tipo, e.SerieId }).IsUnique();
        }
    }
}