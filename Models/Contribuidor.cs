using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace tcc1_api.Models
{
    public class Contribuidor
    {
        public int Id { get; set; }
        public string Genero { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
        public DateTime DataNasc { get; set; }
        public string Foto { get; set; } = string.Empty;
        public List<Contribui> Contribuicoes { get; set; } = new List<Contribui>();
    }

    public class ContribuidorConfiguration : IEntityTypeConfiguration<Contribuidor>
    {
        public void Configure(EntityTypeBuilder<Contribuidor> builder)
        {
            // builder.HasKey(e => new { e.Nome, e.DataNasc });
            builder.HasIndex(e => new { e.Nome, e.DataNasc }).IsUnique();
        }
    }
}