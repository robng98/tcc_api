using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace tcc1_api.Models
{
    public class Exemplar
    {
        public int Id { get; set; }
        public string EstadoConservacao { get; set; } = string.Empty;
        public DateTime DataAquisicao { get; set; }
        public int EdicaoId { get; set; }
        public Edicao? Edicao { get; set; }
        public int ColecaoId { get; set; }
        public Colecao? Colecao { get; set; }
    }

    public class ExemplarConfiguration : IEntityTypeConfiguration<Exemplar>
    {
        public void Configure(EntityTypeBuilder<Exemplar> builder)
        {
            // builder.HasKey(e => new { e.Numero, e.DataLancamento, e.SerieNomeInter, e.SerieCicloNum });
            // builder.HasIndex(e => new { e.Numero, e.DataAquisicao, e.SerieId }).IsUnique();
            // builder.ToTable("Edicoes");
        }
    }
}