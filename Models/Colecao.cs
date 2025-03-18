using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace tcc1_api.Models
{
    public class Colecao
    {
        public int Id { get; set; }
        public string NomeColecao { get; set; } = string.Empty;
        public string AppUserId { get; set; } = string.Empty;
        public AppUser? AppUser { get; set; }
        public List<Exemplar> Exemplares { get; set; } = new List<Exemplar>();
    }

    public class ColecaoConfiguration : IEntityTypeConfiguration<Colecao>
    {
        public void Configure(EntityTypeBuilder<Colecao> builder)
        {
            // builder.HasKey(e => new { e.Numero, e.DataLancamento, e.SerieNomeInter, e.SerieCicloNum });
            builder.HasIndex(e => new { e.NomeColecao}).IsUnique();
            // builder.ToTable("Edicoes");
        }
    }
}