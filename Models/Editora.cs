using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace tcc1_api.Models
{
    public class Editora
    {
        public int Id { get; set; }
        public DateTime AnoCriacao { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string? Logo { get; set; } = string.Empty;
        public List<Serie> Series { get; set; } = new List<Serie>();
    }

    public class EditoraConfiguration : IEntityTypeConfiguration<Editora>
    {
        public void Configure(EntityTypeBuilder<Editora> builder)
        {
            // builder.HasKey(e => new { e.AnoCriacao, e.Nome });
            builder.HasIndex(e => new { e.AnoCriacao, e.Nome }).IsUnique();
        }
    }
}