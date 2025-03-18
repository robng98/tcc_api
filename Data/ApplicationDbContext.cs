using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using tcc1_api.Models;

namespace tcc1_api.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {

        public ApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
    
        }

        public DbSet<Editora> Editoras { get; set; }
        public DbSet<Serie> Series { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Manga> Mangas { get; set; }
        public DbSet<Contribui> Contribui { get; set; }
        public DbSet<Contribuidor> Contribuidores { get; set; }
        public DbSet<Edicao> Edicoes { get; set; }
        public DbSet<Tankobon> Tankobons { get; set; }
        public DbSet<Exemplar> Exemplares { get; set; }
        public DbSet<Colecao> Colecoes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new EditoraConfiguration());
            modelBuilder.ApplyConfiguration(new SerieConfiguration());
            modelBuilder.ApplyConfiguration(new GeneroConfiguration());
            modelBuilder.ApplyConfiguration(new MangaConfiguration());
            modelBuilder.ApplyConfiguration(new ContribuiConfiguration());
            modelBuilder.ApplyConfiguration(new ContribuidorConfiguration());
            modelBuilder.ApplyConfiguration(new EdicaoConfiguration());
            modelBuilder.ApplyConfiguration(new TankobonConfiguration());
            modelBuilder.ApplyConfiguration(new ExemplarConfiguration());
            modelBuilder.ApplyConfiguration(new ColecaoConfiguration());

            // Seed Editoras data
            modelBuilder.Entity<Editora>().HasData(
                new Editora { Id = 1, AnoCriacao = DateTime.SpecifyKind(DateTime.Parse("1934-10-06 20:46:22.526+00"), DateTimeKind.Utc), Nome = "DC Comics", Logo = null },
                new Editora { Id = 2, AnoCriacao = DateTime.SpecifyKind(DateTime.Parse("1939-10-06 20:46:22.526+00"), DateTimeKind.Utc), Nome = "Marvel Comics", Logo = null },
                new Editora { Id = 3, AnoCriacao = DateTime.SpecifyKind(DateTime.Parse("1949-10-07 11:06:03.879+00"), DateTimeKind.Utc), Nome = "Shueisha", Logo = null }
            );

            // Seed Series data
            modelBuilder.Entity<Serie>().HasData(
                new Serie { Id = 1, EstadoPubAtual = "FINALIZADO", NomeInter = "The Dark Knight Returns", CicloNum = 1, EditoraId = 1 },
                new Serie { Id = 2, EstadoPubAtual = "FINALIZADO", NomeInter = "Watchmen", CicloNum = 1, EditoraId = 1 },
                new Serie { Id = 3, EstadoPubAtual = "EM ANDAMENTO", NomeInter = "Immortal Thor", CicloNum = 1, EditoraId = 2 },
                new Serie { Id = 4, EstadoPubAtual = "FINALIZADO", NomeInter = "Marvels", CicloNum = 1, EditoraId = 2 },
                new Serie { Id = 5, EstadoPubAtual = "EM ANDAMENTO", NomeInter = "One Punch-Man", CicloNum = 1, EditoraId = 3 }
            );

            // Seed Mangas data
            modelBuilder.Entity<Manga>().HasData(
                new Manga { Id = 1, NomeJap = "ワンパンマン", Demografia = "Seinen", SerieId = 5 }
            );

            // Seed Generos data
            modelBuilder.Entity<Genero>().HasData(
                new Genero { Id = 1, Tipo = "Drama", SerieId = 1 },
                new Genero { Id = 2, Tipo = "Ação", SerieId = 5 },
                new Genero { Id = 3, Tipo = "Drama", SerieId = 2 },
                new Genero { Id = 4, Tipo = "Fantasia", SerieId = 3 },
                new Genero { Id = 5, Tipo = "Drama", SerieId = 4 }
            );

            // Seed Contribuidores data
            modelBuilder.Entity<Contribuidor>().HasData(
                new Contribuidor { Id = 1, Genero = "M", Nome = "Frank Miller", DataNasc = DateTime.SpecifyKind(DateTime.Parse("1957-01-27 00:00:00"), DateTimeKind.Utc), Foto = "foto" },
                new Contribuidor { Id = 2, Genero = "M", Nome = "Alan Moore", DataNasc = DateTime.SpecifyKind(DateTime.Parse("1953-11-18 00:00:00"), DateTimeKind.Utc), Foto = "foto" },
                new Contribuidor { Id = 3, Genero = "M", Nome = "Dave Gibbons", DataNasc = DateTime.SpecifyKind(DateTime.Parse("1949-04-14 00:00:00"), DateTimeKind.Utc), Foto = "foto" },
                new Contribuidor { Id = 5, Genero = "M", Nome = "Yusuke Murata", DataNasc = DateTime.SpecifyKind(DateTime.Parse("1986-10-29 00:00:00"), DateTimeKind.Utc), Foto = "foto" },
                new Contribuidor { Id = 6, Genero = "M", Nome = "Al Ewing", DataNasc = DateTime.SpecifyKind(DateTime.Parse("1977-08-12 00:00:00"), DateTimeKind.Utc), Foto = "foto" },
                new Contribuidor { Id = 7, Genero = "M", Nome = "Martin Coccolo", DataNasc = DateTime.SpecifyKind(DateTime.Parse("1983-05-25 00:00:00"), DateTimeKind.Utc), Foto = "foto" },
                new Contribuidor { Id = 8, Genero = "M", Nome = "Ibraim Roberson", DataNasc = DateTime.SpecifyKind(DateTime.Parse("1980-01-01 00:00:00"), DateTimeKind.Utc), Foto = "foto" },
                new Contribuidor { Id = 9, Genero = "M", Nome = "Carlos Magno", DataNasc = DateTime.SpecifyKind(DateTime.Parse("1980-01-01 00:00:00"), DateTimeKind.Utc), Foto = "foto" },
                new Contribuidor { Id = 10, Genero = "F", Nome = "Valentina Pinti", DataNasc = DateTime.SpecifyKind(DateTime.Parse("1990-01-01 00:00:00"), DateTimeKind.Utc), Foto = "foto" },
                new Contribuidor { Id = 11, Genero = "F", Nome = "Jan Bazaldua", DataNasc = DateTime.SpecifyKind(DateTime.Parse("1985-02-01 00:00:00"), DateTimeKind.Utc), Foto = "foto" },
                new Contribuidor { Id = 12, Genero = "M", Nome = "Kurt Busiek", DataNasc = DateTime.SpecifyKind(DateTime.Parse("1960-09-16 00:00:00"), DateTimeKind.Utc), Foto = "foto" },
                new Contribuidor { Id = 13, Genero = "M", Nome = "Alex Ross", DataNasc = DateTime.SpecifyKind(DateTime.Parse("1970-01-22 00:00:00"), DateTimeKind.Utc), Foto = "foto" }
            );

            // Seed Edicoes data
            modelBuilder.Entity<Edicao>().HasData(
                new Edicao { Id = 7, FotoCapa = "https://robng-tcc-arquivos.s3.us-east-1.amazonaws.com/One_Punch_Man/OPM_1/OPM_1.png", Numero = "1", UnMonetaria = "JPY", Preco = 440, DataLancamento = DateTime.SpecifyKind(DateTime.Parse("2012-12-08 17:04:13.155+00"), DateTimeKind.Utc), SerieId = 5 },
                new Edicao { Id = 8, FotoCapa = "https://robng-tcc-arquivos.s3.us-east-1.amazonaws.com/One_Punch_Man/OPM_2/OPM_2.png", Numero = "2", UnMonetaria = "JPY", Preco = 440, DataLancamento = DateTime.SpecifyKind(DateTime.Parse("2012-12-04 17:04:13.155+00"), DateTimeKind.Utc), SerieId = 5 },
                new Edicao { Id = 9, FotoCapa = "https://robng-tcc-arquivos.s3.us-east-1.amazonaws.com/One_Punch_Man/OPM_3/OPM_3.png", Numero = "3", UnMonetaria = "JPY", Preco = 440, DataLancamento = DateTime.SpecifyKind(DateTime.Parse("2013-04-04 17:04:13.155+00"), DateTimeKind.Utc), SerieId = 5 },
                new Edicao { Id = 10, FotoCapa = "https://robng-tcc-arquivos.s3.us-east-1.amazonaws.com/One_Punch_Man/OPM_4/OPM_4.png", Numero = "4", UnMonetaria = "JPY", Preco = 440, DataLancamento = DateTime.SpecifyKind(DateTime.Parse("2013-08-02 17:04:13.155+00"), DateTimeKind.Utc), SerieId = 5 },
                new Edicao { Id = 11, FotoCapa = "https://robng-tcc-arquivos.s3.us-east-1.amazonaws.com/One_Punch_Man/OPM_5/OPM_5.png", Numero = "5", UnMonetaria = "JPY", Preco = 440, DataLancamento = DateTime.SpecifyKind(DateTime.Parse("2013-12-04 17:04:13.155+00"), DateTimeKind.Utc), SerieId = 5 },
                new Edicao { Id = 12, FotoCapa = "https://robng-tcc-arquivos.s3.us-east-1.amazonaws.com/One_Punch_Man/OPM_6/OPM_6.png", Numero = "6", UnMonetaria = "JPY", Preco = 440, DataLancamento = DateTime.SpecifyKind(DateTime.Parse("2014-05-02 17:04:13.155+00"), DateTimeKind.Utc), SerieId = 5 },
                new Edicao { Id = 13, FotoCapa = "https://robng-tcc-arquivos.s3.us-east-1.amazonaws.com/One_Punch_Man/OPM_7/OPM_7.png", Numero = "7", UnMonetaria = "JPY", Preco = 440, DataLancamento = DateTime.SpecifyKind(DateTime.Parse("2014-12-04 17:04:13.155+00"), DateTimeKind.Utc), SerieId = 5 },
                new Edicao { Id = 14, FotoCapa = "https://robng-tcc-arquivos.s3.us-east-1.amazonaws.com/One_Punch_Man/OPM_8/OPM_8.png", Numero = "8", UnMonetaria = "JPY", Preco = 440, DataLancamento = DateTime.SpecifyKind(DateTime.Parse("2015-04-03 17:04:13.155+00"), DateTimeKind.Utc), SerieId = 5 },
                new Edicao { Id = 15, FotoCapa = "https://robng-tcc-arquivos.s3.us-east-1.amazonaws.com/One_Punch_Man/OPM_9/OPM_9.png", Numero = "9", UnMonetaria = "JPY", Preco = 440, DataLancamento = DateTime.SpecifyKind(DateTime.Parse("2015-08-04 17:04:13.155+00"), DateTimeKind.Utc), SerieId = 5 },
                new Edicao { Id = 16, FotoCapa = "https://robng-tcc-arquivos.s3.us-east-1.amazonaws.com/One_Punch_Man/OPM_10/OPM_10.png", Numero = "10", UnMonetaria = "JPY", Preco = 440, DataLancamento = DateTime.SpecifyKind(DateTime.Parse("2015-12-04 17:04:13.155+00"), DateTimeKind.Utc), SerieId = 5 },
                
                new Edicao { Id = 37, FotoCapa = "https://robng-tcc-arquivos.s3.us-east-1.amazonaws.com/Immortal_Thor_Vol_1/Immortal_Thor_Vol_1_1/Immortal_Thor_Vol_1_1.jpg", Numero = "1A", UnMonetaria = "USD", Preco = 6.99m, DataLancamento = DateTime.SpecifyKind(DateTime.Parse("2023-10-01 19:37:26.156+00"), DateTimeKind.Utc), SerieId = 3 },
                new Edicao { Id = 38, FotoCapa = "https://robng-tcc-arquivos.s3.us-east-1.amazonaws.com/Immortal_Thor_Vol_1/Immortal_Thor_Vol_1_2/Immortal_Thor_Vol_1_2.jpg", Numero = "2A", UnMonetaria = "USD", Preco = 4.99m, DataLancamento = DateTime.SpecifyKind(DateTime.Parse("2023-11-01 19:37:26.156+00"), DateTimeKind.Utc), SerieId = 3 },
                new Edicao { Id = 39, FotoCapa = "https://robng-tcc-arquivos.s3.us-east-1.amazonaws.com/Immortal_Thor_Vol_1/Immortal_Thor_Vol_1_3/Immortal_Thor_Vol_1_3.jpg", Numero = "3A", UnMonetaria = "USD", Preco = 4.99m, DataLancamento = DateTime.SpecifyKind(DateTime.Parse("2023-12-01 19:37:26.156+00"), DateTimeKind.Utc), SerieId = 3 },
                new Edicao { Id = 40, FotoCapa = "https://robng-tcc-arquivos.s3.us-east-1.amazonaws.com/Immortal_Thor_Vol_1/Immortal_Thor_Vol_1_4/Immortal_Thor_Vol_1_4.jpg", Numero = "4A", UnMonetaria = "USD", Preco = 4.99m, DataLancamento = DateTime.SpecifyKind(DateTime.Parse("2024-01-01 19:37:26.156+00"), DateTimeKind.Utc), SerieId = 3 },
                new Edicao { Id = 41, FotoCapa = "https://robng-tcc-arquivos.s3.us-east-1.amazonaws.com/Immortal_Thor_Vol_1/Immortal_Thor_Vol_1_5/Immortal_Thor_Vol_1_5.jpg", Numero = "5A", UnMonetaria = "USD", Preco = 4.99m, DataLancamento = DateTime.SpecifyKind(DateTime.Parse("2024-02-01 19:37:26.156+00"), DateTimeKind.Utc), SerieId = 3 },
                new Edicao { Id = 42, FotoCapa = "https://robng-tcc-arquivos.s3.us-east-1.amazonaws.com/Immortal_Thor_Vol_1/Immortal_Thor_Vol_1_6/Immortal_Thor_Vol_1_6.jpg", Numero = "6A", UnMonetaria = "USD", Preco = 4.99m, DataLancamento = DateTime.SpecifyKind(DateTime.Parse("2024-03-01 19:37:26.156+00"), DateTimeKind.Utc), SerieId = 3 },
                new Edicao { Id = 43, FotoCapa = "https://robng-tcc-arquivos.s3.us-east-1.amazonaws.com/Immortal_Thor_Vol_1/Immortal_Thor_Vol_1_7/Immortal_Thor_Vol_1_7.jpg", Numero = "7A", UnMonetaria = "USD", Preco = 4.99m, DataLancamento = DateTime.SpecifyKind(DateTime.Parse("2024-04-01 19:37:26.156+00"), DateTimeKind.Utc), SerieId = 3 },
                new Edicao { Id = 44, FotoCapa = "https://robng-tcc-arquivos.s3.us-east-1.amazonaws.com/Immortal_Thor_Vol_1/Immortal_Thor_Vol_1_8/Immortal_Thor_Vol_1_8.jpg", Numero = "8A", UnMonetaria = "USD", Preco = 4.99m, DataLancamento = DateTime.SpecifyKind(DateTime.Parse("2024-05-01 19:37:26.156+00"), DateTimeKind.Utc), SerieId = 3 },
                new Edicao { Id = 45, FotoCapa = "https://robng-tcc-arquivos.s3.us-east-1.amazonaws.com/Immortal_Thor_Vol_1/Immortal_Thor_Vol_1_9/Immortal_Thor_Vol_1_9.jpg", Numero = "9A", UnMonetaria = "USD", Preco = 4.99m, DataLancamento = DateTime.SpecifyKind(DateTime.Parse("2024-06-01 19:37:26.156+00"), DateTimeKind.Utc), SerieId = 3 },
                new Edicao { Id = 46, FotoCapa = "https://robng-tcc-arquivos.s3.us-east-1.amazonaws.com/Immortal_Thor_Vol_1/Immortal_Thor_Vol_1_10/Immortal_Thor_Vol_1_10.jpg", Numero = "10A", UnMonetaria = "USD", Preco = 4.99m, DataLancamento = DateTime.SpecifyKind(DateTime.Parse("2024-07-01 19:37:26.156+00"), DateTimeKind.Utc), SerieId = 3 },
                new Edicao { Id = 47, FotoCapa = "https://robng-tcc-arquivos.s3.us-east-1.amazonaws.com/Immortal_Thor_Vol_1/Immortal_Thor_Vol_1_11/Immortal_Thor_Vol_1_11.jpg", Numero = "11A", UnMonetaria = "USD", Preco = 4.99m, DataLancamento = DateTime.SpecifyKind(DateTime.Parse("2024-07-01 19:37:26.156+00"), DateTimeKind.Utc), SerieId = 3 },
                new Edicao { Id = 48, FotoCapa = "https://robng-tcc-arquivos.s3.us-east-1.amazonaws.com/Immortal_Thor_Vol_1/Immortal_Thor_Vol_1_12/Immortal_Thor_Vol_1_12.jpg", Numero = "12A", UnMonetaria = "USD", Preco = 4.99m, DataLancamento = DateTime.SpecifyKind(DateTime.Parse("2024-08-01 19:37:26.156+00"), DateTimeKind.Utc), SerieId = 3 },
                new Edicao { Id = 49, FotoCapa = "https://robng-tcc-arquivos.s3.us-east-1.amazonaws.com/Immortal_Thor_Vol_1/Immortal_Thor_Vol_1_13/Immortal_Thor_Vol_1_13.jpg", Numero = "13A", UnMonetaria = "USD", Preco = 4.99m, DataLancamento = DateTime.SpecifyKind(DateTime.Parse("2024-10-01 19:37:26.156+00"), DateTimeKind.Utc), SerieId = 3 },
                new Edicao { Id = 50, FotoCapa = "https://robng-tcc-arquivos.s3.us-east-1.amazonaws.com/Immortal_Thor_Vol_1/Immortal_Thor_Vol_1_14/Immortal_Thor_Vol_1_14.jpg", Numero = "14A", UnMonetaria = "USD", Preco = 4.99m, DataLancamento = DateTime.SpecifyKind(DateTime.Parse("2024-10-01 19:37:26.156+00"), DateTimeKind.Utc), SerieId = 3 },
                
                new Edicao { Id = 33, FotoCapa = "https://robng-tcc-arquivos.s3.us-east-1.amazonaws.com/Marvels_Vol_1/Marvels_Vol_1_1/Marvels_Vol_1_1.jpg", Numero = "1A", UnMonetaria = "USD", Preco = 5.95m, DataLancamento = DateTime.SpecifyKind(DateTime.Parse("1994-01-01 19:37:26.156+00"), DateTimeKind.Utc), SerieId = 4 },
                new Edicao { Id = 34, FotoCapa = "https://robng-tcc-arquivos.s3.us-east-1.amazonaws.com/Marvels_Vol_1/Marvels_Vol_1_2/Marvels_Vol_1_2.jpg", Numero = "2A", UnMonetaria = "USD", Preco = 5.95m, DataLancamento = DateTime.SpecifyKind(DateTime.Parse("1994-02-01 19:37:26.156+00"), DateTimeKind.Utc), SerieId = 4 },
                new Edicao { Id = 35, FotoCapa = "https://robng-tcc-arquivos.s3.us-east-1.amazonaws.com/Marvels_Vol_1/Marvels_Vol_1_3/Marvels_Vol_1_3.jpg", Numero = "3A", UnMonetaria = "USD", Preco = 5.95m, DataLancamento = DateTime.SpecifyKind(DateTime.Parse("1994-03-01 19:37:26.156+00"), DateTimeKind.Utc), SerieId = 4 },
                new Edicao { Id = 36, FotoCapa = "https://robng-tcc-arquivos.s3.us-east-1.amazonaws.com/Marvels_Vol_1/Marvels_Vol_1_4/Marvels_Vol_1_4.jpg", Numero = "4A", UnMonetaria = "USD", Preco = 5.95m, DataLancamento = DateTime.SpecifyKind(DateTime.Parse("1994-04-01 19:37:26.156+00"), DateTimeKind.Utc), SerieId = 4 },
                
                new Edicao { Id = 3, FotoCapa = "https://robng-tcc-arquivos.s3.us-east-1.amazonaws.com/Batman_-_Dark_Knight_Returns/Batman_-_Dark_Knight_Returns_1/Batman_-_Dark_Knight_Returns_1.jpg", Numero = "1A", UnMonetaria = "USD", Preco = 2.95m, DataLancamento = DateTime.SpecifyKind(DateTime.Parse("1986-03-01 16:23:50.846+00"), DateTimeKind.Utc), SerieId = 1 },
                new Edicao { Id = 17, FotoCapa = "https://robng-tcc-arquivos.s3.us-east-1.amazonaws.com/Batman_-_Dark_Knight_Returns/Batman_-_Dark_Knight_Returns_2/Batman_-_Dark_Knight_Returns_2.jpg", Numero = "2A", UnMonetaria = "USD", Preco = 2.95m, DataLancamento = DateTime.SpecifyKind(DateTime.Parse("1986-04-01 19:37:26.156+00"), DateTimeKind.Utc), SerieId = 1 },
                new Edicao { Id = 18, FotoCapa = "https://robng-tcc-arquivos.s3.us-east-1.amazonaws.com/Batman_-_Dark_Knight_Returns/Batman_-_Dark_Knight_Returns_3/Batman_-_Dark_Knight_Returns_3.jpg", Numero = "3A", UnMonetaria = "USD", Preco = 2.95m, DataLancamento = DateTime.SpecifyKind(DateTime.Parse("1986-05-01 19:37:26.156+00"), DateTimeKind.Utc), SerieId = 1 },
                new Edicao { Id = 19, FotoCapa = "https://robng-tcc-arquivos.s3.us-east-1.amazonaws.com/Batman_-_Dark_Knight_Returns/Batman_-_Dark_Knight_Returns_4/Batman_-_Dark_Knight_Returns_4.jpg", Numero = "4A", UnMonetaria = "USD", Preco = 2.95m, DataLancamento = DateTime.SpecifyKind(DateTime.Parse("1986-06-01 19:37:26.156+00"), DateTimeKind.Utc), SerieId = 1 },
                
                new Edicao { Id = 20, FotoCapa = "https://robng-tcc-arquivos.s3.us-east-1.amazonaws.com/Watchmen_Vol_1/Watchmen_Vol_1_1/Watchmen_1.jpg", Numero = "1A", UnMonetaria = "USD", Preco = 1.50m, DataLancamento = DateTime.SpecifyKind(DateTime.Parse("1986-09-01 19:37:26.156+00"), DateTimeKind.Utc), SerieId = 2 },
                new Edicao { Id = 21, FotoCapa = "https://robng-tcc-arquivos.s3.us-east-1.amazonaws.com/Watchmen_Vol_1/Watchmen_Vol_1_2/Watchmen_2.jpg", Numero = "2A", UnMonetaria = "USD", Preco = 1.50m, DataLancamento = DateTime.SpecifyKind(DateTime.Parse("1986-10-01 19:37:26.156+00"), DateTimeKind.Utc), SerieId = 2 },
                new Edicao { Id = 22, FotoCapa = "https://robng-tcc-arquivos.s3.us-east-1.amazonaws.com/Watchmen_Vol_1/Watchmen_Vol_1_3/Watchmen_3.jpg", Numero = "3A", UnMonetaria = "USD", Preco = 1.50m, DataLancamento = DateTime.SpecifyKind(DateTime.Parse("1986-11-01 19:37:26.156+00"), DateTimeKind.Utc), SerieId = 2 },
                new Edicao { Id = 23, FotoCapa = "https://robng-tcc-arquivos.s3.us-east-1.amazonaws.com/Watchmen_Vol_1/Watchmen_Vol_1_4/Watchmen_4.jpg", Numero = "4A", UnMonetaria = "USD", Preco = 1.50m, DataLancamento = DateTime.SpecifyKind(DateTime.Parse("1986-12-01 19:37:26.156+00"), DateTimeKind.Utc), SerieId = 2 },
                new Edicao { Id = 24, FotoCapa = "https://robng-tcc-arquivos.s3.us-east-1.amazonaws.com/Watchmen_Vol_1/Watchmen_Vol_1_5/Watchmen_5.jpg", Numero = "5A", UnMonetaria = "USD", Preco = 1.50m, DataLancamento = DateTime.SpecifyKind(DateTime.Parse("1987-01-01 19:37:26.156+00"), DateTimeKind.Utc), SerieId = 2 },
                new Edicao { Id = 25, FotoCapa = "https://robng-tcc-arquivos.s3.us-east-1.amazonaws.com/Watchmen_Vol_1/Watchmen_Vol_1_6/Watchmen_6.jpg", Numero = "6A", UnMonetaria = "USD", Preco = 1.50m, DataLancamento = DateTime.SpecifyKind(DateTime.Parse("1987-02-01 19:37:26.156+00"), DateTimeKind.Utc), SerieId = 2 },
                new Edicao { Id = 26, FotoCapa = "https://robng-tcc-arquivos.s3.us-east-1.amazonaws.com/Watchmen_Vol_1/Watchmen_Vol_1_7/Watchmen_7.jpg", Numero = "7A", UnMonetaria = "USD", Preco = 1.50m, DataLancamento = DateTime.SpecifyKind(DateTime.Parse("1987-03-01 19:37:26.156+00"), DateTimeKind.Utc), SerieId = 2 },
                new Edicao { Id = 27, FotoCapa = "https://robng-tcc-arquivos.s3.us-east-1.amazonaws.com/Watchmen_Vol_1/Watchmen_Vol_1_8/Watchmen_8.jpg", Numero = "8A", UnMonetaria = "USD", Preco = 1.50m, DataLancamento = DateTime.SpecifyKind(DateTime.Parse("1987-04-01 19:37:26.156+00"), DateTimeKind.Utc), SerieId = 2 },
                new Edicao { Id = 29, FotoCapa = "https://robng-tcc-arquivos.s3.us-east-1.amazonaws.com/Watchmen_Vol_1/Watchmen_Vol_1_9/Watchmen_9.jpg", Numero = "9A", UnMonetaria = "USD", Preco = 1.50m, DataLancamento = DateTime.SpecifyKind(DateTime.Parse("1987-05-01 19:37:26.156+00"), DateTimeKind.Utc), SerieId = 2 },
                new Edicao { Id = 30, FotoCapa = "https://robng-tcc-arquivos.s3.us-east-1.amazonaws.com/Watchmen_Vol_1/Watchmen_Vol_1_10/Watchmen_10.jpg", Numero = "10A", UnMonetaria = "USD", Preco = 1.50m, DataLancamento = DateTime.SpecifyKind(DateTime.Parse("1987-07-01 19:37:26.156+00"), DateTimeKind.Utc), SerieId = 2 },
                new Edicao { Id = 31, FotoCapa = "https://robng-tcc-arquivos.s3.us-east-1.amazonaws.com/Watchmen_Vol_1/Watchmen_Vol_1_11/Watchmen_11.jpg", Numero = "11A", UnMonetaria = "USD", Preco = 1.50m, DataLancamento = DateTime.SpecifyKind(DateTime.Parse("1987-08-01 19:37:26.156+00"), DateTimeKind.Utc), SerieId = 2 },
                new Edicao { Id = 32, FotoCapa = "https://robng-tcc-arquivos.s3.us-east-1.amazonaws.com/Watchmen_Vol_1/Watchmen_Vol_1_12/Watchmen_12.jpg", Numero = "12A", UnMonetaria = "USD", Preco = 1.50m, DataLancamento = DateTime.SpecifyKind(DateTime.Parse("1987-10-01 19:37:26.156+00"), DateTimeKind.Utc), SerieId = 2 }
            );

            // Seed Tankobons data
            modelBuilder.Entity<Tankobon>().HasData(
                new Tankobon { Id = 1, EdicaoId = 7, NumeroCapitulos = 8 },
                new Tankobon { Id = 2, EdicaoId = 8, NumeroCapitulos = 5 },
                new Tankobon { Id = 3, EdicaoId = 9, NumeroCapitulos = 8 },
                new Tankobon { Id = 4, EdicaoId = 10, NumeroCapitulos = 6 },
                new Tankobon { Id = 5, EdicaoId = 11, NumeroCapitulos = 7 },
                new Tankobon { Id = 6, EdicaoId = 12, NumeroCapitulos = 8 },
                new Tankobon { Id = 7, EdicaoId = 13, NumeroCapitulos = 8 },
                new Tankobon { Id = 8, EdicaoId = 14, NumeroCapitulos = 8 },
                new Tankobon { Id = 9, EdicaoId = 15, NumeroCapitulos = 8 },
                new Tankobon { Id = 10, EdicaoId = 16, NumeroCapitulos = 11 }
            );

            // Seed Contribui data
            modelBuilder.Entity<Contribui>().HasData(
                // Frank Miller
                new Contribui { ContribuidorId = 1, EdicaoId = 3, Funcao = "Roteirista" },
                new Contribui { ContribuidorId = 1, EdicaoId = 17, Funcao = "Roteirista" },
                new Contribui { ContribuidorId = 1, EdicaoId = 18, Funcao = "Roteirista" },
                new Contribui { ContribuidorId = 1, EdicaoId = 19, Funcao = "Roteirista" },
                new Contribui { ContribuidorId = 1, EdicaoId = 3, Funcao = "Desenhista" },
                new Contribui { ContribuidorId = 1, EdicaoId = 17, Funcao = "Desenhista" },
                new Contribui { ContribuidorId = 1, EdicaoId = 18, Funcao = "Desenhista" },
                new Contribui { ContribuidorId = 1, EdicaoId = 19, Funcao = "Desenhista" },
                
                // Alan Moore
                new Contribui { ContribuidorId = 2, EdicaoId = 20, Funcao = "Roteirista" },
                new Contribui { ContribuidorId = 2, EdicaoId = 21, Funcao = "Roteirista" },
                new Contribui { ContribuidorId = 2, EdicaoId = 22, Funcao = "Roteirista" },
                new Contribui { ContribuidorId = 2, EdicaoId = 23, Funcao = "Roteirista" },
                new Contribui { ContribuidorId = 2, EdicaoId = 24, Funcao = "Roteirista" },
                new Contribui { ContribuidorId = 2, EdicaoId = 25, Funcao = "Roteirista" },
                new Contribui { ContribuidorId = 2, EdicaoId = 26, Funcao = "Roteirista" },
                new Contribui { ContribuidorId = 2, EdicaoId = 27, Funcao = "Roteirista" },
                new Contribui { ContribuidorId = 2, EdicaoId = 29, Funcao = "Roteirista" },
                new Contribui { ContribuidorId = 2, EdicaoId = 30, Funcao = "Roteirista" },
                new Contribui { ContribuidorId = 2, EdicaoId = 31, Funcao = "Roteirista" },
                new Contribui { ContribuidorId = 2, EdicaoId = 32, Funcao = "Roteirista" },
                
                // Dave Gibbons
                new Contribui { ContribuidorId = 3, EdicaoId = 20, Funcao = "Roteirista" },
                new Contribui { ContribuidorId = 3, EdicaoId = 21, Funcao = "Roteirista" },
                new Contribui { ContribuidorId = 3, EdicaoId = 22, Funcao = "Roteirista" },
                new Contribui { ContribuidorId = 3, EdicaoId = 23, Funcao = "Roteirista" },
                new Contribui { ContribuidorId = 3, EdicaoId = 24, Funcao = "Roteirista" },
                new Contribui { ContribuidorId = 3, EdicaoId = 25, Funcao = "Roteirista" },
                new Contribui { ContribuidorId = 3, EdicaoId = 26, Funcao = "Roteirista" },
                new Contribui { ContribuidorId = 3, EdicaoId = 27, Funcao = "Roteirista" },
                new Contribui { ContribuidorId = 3, EdicaoId = 29, Funcao = "Roteirista" },
                new Contribui { ContribuidorId = 3, EdicaoId = 30, Funcao = "Roteirista" },
                new Contribui { ContribuidorId = 3, EdicaoId = 31, Funcao = "Roteirista" },
                new Contribui { ContribuidorId = 3, EdicaoId = 32, Funcao = "Roteirista" },
                
                // Yusuke Murata
                new Contribui { ContribuidorId = 5, EdicaoId = 7, Funcao = "Mangaka" },
                new Contribui { ContribuidorId = 5, EdicaoId = 8, Funcao = "Mangaka" },
                new Contribui { ContribuidorId = 5, EdicaoId = 9, Funcao = "Mangaka" },
                new Contribui { ContribuidorId = 5, EdicaoId = 10, Funcao = "Mangaka" },
                new Contribui { ContribuidorId = 5, EdicaoId = 11, Funcao = "Mangaka" },
                new Contribui { ContribuidorId = 5, EdicaoId = 12, Funcao = "Mangaka" },
                new Contribui { ContribuidorId = 5, EdicaoId = 13, Funcao = "Mangaka" },
                new Contribui { ContribuidorId = 5, EdicaoId = 14, Funcao = "Mangaka" },
                new Contribui { ContribuidorId = 5, EdicaoId = 15, Funcao = "Mangaka" },
                new Contribui { ContribuidorId = 5, EdicaoId = 16, Funcao = "Mangaka" },
                
                // Al Ewing
                new Contribui { ContribuidorId = 6, EdicaoId = 37, Funcao = "Roteirista" },
                new Contribui { ContribuidorId = 6, EdicaoId = 38, Funcao = "Roteirista" },
                new Contribui { ContribuidorId = 6, EdicaoId = 39, Funcao = "Roteirista" },
                new Contribui { ContribuidorId = 6, EdicaoId = 40, Funcao = "Roteirista" },
                new Contribui { ContribuidorId = 6, EdicaoId = 41, Funcao = "Roteirista" },
                new Contribui { ContribuidorId = 6, EdicaoId = 42, Funcao = "Roteirista" },
                new Contribui { ContribuidorId = 6, EdicaoId = 43, Funcao = "Roteirista" },
                new Contribui { ContribuidorId = 6, EdicaoId = 44, Funcao = "Roteirista" },
                new Contribui { ContribuidorId = 6, EdicaoId = 45, Funcao = "Roteirista" },
                new Contribui { ContribuidorId = 6, EdicaoId = 46, Funcao = "Roteirista" },
                new Contribui { ContribuidorId = 6, EdicaoId = 47, Funcao = "Roteirista" },
                new Contribui { ContribuidorId = 6, EdicaoId = 48, Funcao = "Roteirista" },
                new Contribui { ContribuidorId = 6, EdicaoId = 49, Funcao = "Roteirista" },
                new Contribui { ContribuidorId = 6, EdicaoId = 50, Funcao = "Roteirista" },
                
                // Martin Coccolo
                new Contribui { ContribuidorId = 7, EdicaoId = 37, Funcao = "Desenhista" },
                new Contribui { ContribuidorId = 7, EdicaoId = 38, Funcao = "Desenhista" },
                new Contribui { ContribuidorId = 7, EdicaoId = 39, Funcao = "Desenhista" },
                new Contribui { ContribuidorId = 7, EdicaoId = 40, Funcao = "Desenhista" },
                new Contribui { ContribuidorId = 7, EdicaoId = 41, Funcao = "Desenhista" },
                new Contribui { ContribuidorId = 7, EdicaoId = 42, Funcao = "Desenhista" },
                new Contribui { ContribuidorId = 7, EdicaoId = 43, Funcao = "Desenhista" },
                
                // Ibraim Roberson
                new Contribui { ContribuidorId = 8, EdicaoId = 44, Funcao = "Desenhista" },
                new Contribui { ContribuidorId = 8, EdicaoId = 45, Funcao = "Desenhista" },
                
                // Carlos Magno
                new Contribui { ContribuidorId = 9, EdicaoId = 46, Funcao = "Desenhista" },
                
                // Valentina Pinti
                new Contribui { ContribuidorId = 10, EdicaoId = 47, Funcao = "Desenhista" },
                new Contribui { ContribuidorId = 10, EdicaoId = 48, Funcao = "Desenhista" },
                
                // Jan Bazaldua
                new Contribui { ContribuidorId = 11, EdicaoId = 49, Funcao = "Desenhista" },
                new Contribui { ContribuidorId = 11, EdicaoId = 50, Funcao = "Desenhista" },
                
                // Kurt Busiek
                new Contribui { ContribuidorId = 12, EdicaoId = 33, Funcao = "Roteirista" },
                new Contribui { ContribuidorId = 12, EdicaoId = 34, Funcao = "Roteirista" },
                new Contribui { ContribuidorId = 12, EdicaoId = 35, Funcao = "Roteirista" },
                new Contribui { ContribuidorId = 12, EdicaoId = 36, Funcao = "Roteirista" },
                
                // Alex Ross
                new Contribui { ContribuidorId = 13, EdicaoId = 33, Funcao = "Desenhista" },
                new Contribui { ContribuidorId = 13, EdicaoId = 34, Funcao = "Desenhista" },
                new Contribui { ContribuidorId = 13, EdicaoId = 35, Funcao = "Desenhista" },
                new Contribui { ContribuidorId = 13, EdicaoId = 36, Funcao = "Desenhista" }
            );

            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole 
                { 
                    Name = "Admin",
                    NormalizedName = "ADMIN" 
                },
                new IdentityRole 
                { 
                    Name = "User",
                    NormalizedName = "USER"
                },
            };

            modelBuilder.Entity<IdentityRole>().HasData(roles);
        }


    }
}