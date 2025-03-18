using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace tcc1_api.Models
{
    public class Edicao
    {
        public int Id { get; set; }
        public string FotoCapa { get; set; } = string.Empty;
        public string Numero { get; set; } = string.Empty;
        public string UnMonetaria { get; set; } = string.Empty;
        public decimal Preco { get; set; }
        public DateTime DataLancamento { get; set; }

        // public string SerieNomeInter { get; set; } = string.Empty;
        // public int SerieCicloNum { get; set; }
        public int SerieId { get; set; }
        public Serie? Serie { get; set; }
        public List<Exemplar> Exemplares { get; set; } = new List<Exemplar>();

        public Tankobon? Tankobon { get; set; }
        public List<Contribui> Contribuicoes { get; set; } = new List<Contribui>();
        // public List<Exemplar> Exemplares { get; set; } = new List<Exemplar>();
    }

    public class EdicaoConfiguration : IEntityTypeConfiguration<Edicao>
    {
        public void Configure(EntityTypeBuilder<Edicao> builder)
        {
            // builder.HasKey(e => new { e.Numero, e.DataLancamento, e.SerieNomeInter, e.SerieCicloNum });
            builder.HasIndex(e => new { e.Numero, e.DataLancamento, e.SerieId }).IsUnique();
            // builder.ToTable("Edicoes");
        }
    }
}