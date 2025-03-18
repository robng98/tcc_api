using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace tcc1_api.Models
{
    public class Serie
    {
        public int Id { get; set; }
        public string? EstadoPubAtual { get; set; }
        public string NomeInter { get; set; } = string.Empty;
        public int CicloNum { get; set; }
        public List<Genero> Generos { get; set; } = new List<Genero>();
        // public List<Contribui> Contribuicoes { get; set; } = new List<Contribui>();
        // public List<Publica> Publicacoes { get; set; } = new List<Publica>();
        public List<Edicao> Edicoes { get; set; } = new List<Edicao>();
        public Manga? Manga { get; set; }

        public int EditoraId { get; set; }
        public Editora? Editora { get; set; }
    }

    public class SerieConfiguration : IEntityTypeConfiguration<Serie>
    {
        public void Configure(EntityTypeBuilder<Serie> builder)
        {
            // builder.HasKey(e => new { e.NomeInter, e.CicloNum });
            builder.HasIndex(e => new { e.NomeInter, e.CicloNum, e.EditoraId }).IsUnique();
        }
    }
}