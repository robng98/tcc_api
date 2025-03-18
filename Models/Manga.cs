using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace tcc1_api.Models
{
    public class Manga
    {
        public int Id { get; set; }
        public string NomeJap { get; set; } = string.Empty;
        public string Demografia { get; set; } = string.Empty;
        // public string SerieNomeInter { get; set; } = string.Empty;
        // public int SerieCicloNum { get; set; }
        public int SerieId { get; set; }
        public Serie? Serie { get; set; }
    }

    public class MangaConfiguration : IEntityTypeConfiguration<Manga>
    {
        public void Configure(EntityTypeBuilder<Manga> builder)
        {
            // builder.HasKey(e => new { e.SerieNomeInter, e.SerieCicloNum });
            builder.HasIndex(e => new { e.SerieId }).IsUnique();
        }
    }
}