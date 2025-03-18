using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace tcc1_api.Migrations
{
    /// <inheritdoc />
    public partial class Init_SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    FullName = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contribuidores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Genero = table.Column<string>(type: "text", nullable: false),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    DataNasc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Foto = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contribuidores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Editoras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AnoCriacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Logo = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Editoras", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Colecoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NomeColecao = table.Column<string>(type: "text", nullable: false),
                    AppUserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colecoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Colecoes_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Series",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EstadoPubAtual = table.Column<string>(type: "text", nullable: true),
                    NomeInter = table.Column<string>(type: "text", nullable: false),
                    CicloNum = table.Column<int>(type: "integer", nullable: false),
                    EditoraId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Series", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Series_Editoras_EditoraId",
                        column: x => x.EditoraId,
                        principalTable: "Editoras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Edicoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FotoCapa = table.Column<string>(type: "text", nullable: false),
                    Numero = table.Column<string>(type: "text", nullable: false),
                    UnMonetaria = table.Column<string>(type: "text", nullable: false),
                    Preco = table.Column<decimal>(type: "numeric", nullable: false),
                    DataLancamento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    SerieId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edicoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Edicoes_Series_SerieId",
                        column: x => x.SerieId,
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Generos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Tipo = table.Column<string>(type: "text", nullable: false),
                    SerieId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Generos_Series_SerieId",
                        column: x => x.SerieId,
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mangas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NomeJap = table.Column<string>(type: "text", nullable: false),
                    Demografia = table.Column<string>(type: "text", nullable: false),
                    SerieId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mangas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mangas_Series_SerieId",
                        column: x => x.SerieId,
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contribui",
                columns: table => new
                {
                    ContribuidorId = table.Column<int>(type: "integer", nullable: false),
                    EdicaoId = table.Column<int>(type: "integer", nullable: false),
                    Funcao = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contribui", x => new { x.ContribuidorId, x.EdicaoId, x.Funcao });
                    table.ForeignKey(
                        name: "FK_Contribui_Contribuidores_ContribuidorId",
                        column: x => x.ContribuidorId,
                        principalTable: "Contribuidores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contribui_Edicoes_EdicaoId",
                        column: x => x.EdicaoId,
                        principalTable: "Edicoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exemplares",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EstadoConservacao = table.Column<string>(type: "text", nullable: false),
                    DataAquisicao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EdicaoId = table.Column<int>(type: "integer", nullable: false),
                    ColecaoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exemplares", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exemplares_Colecoes_ColecaoId",
                        column: x => x.ColecaoId,
                        principalTable: "Colecoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Exemplares_Edicoes_EdicaoId",
                        column: x => x.EdicaoId,
                        principalTable: "Edicoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tankobons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EdicaoId = table.Column<int>(type: "integer", nullable: false),
                    NumeroCapitulos = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tankobons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tankobons_Edicoes_EdicaoId",
                        column: x => x.EdicaoId,
                        principalTable: "Edicoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4d73186a-f5fb-417b-a08c-c4cdd0fd40bd", null, "Admin", "ADMIN" },
                    { "9426746c-534a-4569-9db0-d3cd125c5cae", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Contribuidores",
                columns: new[] { "Id", "DataNasc", "Foto", "Genero", "Nome" },
                values: new object[,]
                {
                    { 1, new DateTime(1957, 1, 27, 0, 0, 0, 0, DateTimeKind.Utc), "foto", "M", "Frank Miller" },
                    { 2, new DateTime(1953, 11, 18, 0, 0, 0, 0, DateTimeKind.Utc), "foto", "M", "Alan Moore" },
                    { 3, new DateTime(1949, 4, 14, 0, 0, 0, 0, DateTimeKind.Utc), "foto", "M", "Dave Gibbons" },
                    { 5, new DateTime(1986, 10, 29, 0, 0, 0, 0, DateTimeKind.Utc), "foto", "M", "Yusuke Murata" },
                    { 6, new DateTime(1977, 8, 12, 0, 0, 0, 0, DateTimeKind.Utc), "foto", "M", "Al Ewing" },
                    { 7, new DateTime(1983, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "foto", "M", "Martin Coccolo" },
                    { 8, new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "foto", "M", "Ibraim Roberson" },
                    { 9, new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "foto", "M", "Carlos Magno" },
                    { 10, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "foto", "F", "Valentina Pinti" },
                    { 11, new DateTime(1985, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), "foto", "F", "Jan Bazaldua" },
                    { 12, new DateTime(1960, 9, 16, 0, 0, 0, 0, DateTimeKind.Utc), "foto", "M", "Kurt Busiek" },
                    { 13, new DateTime(1970, 1, 22, 0, 0, 0, 0, DateTimeKind.Utc), "foto", "M", "Alex Ross" }
                });

            migrationBuilder.InsertData(
                table: "Editoras",
                columns: new[] { "Id", "AnoCriacao", "Logo", "Nome" },
                values: new object[,]
                {
                    { 1, new DateTime(1934, 10, 6, 17, 46, 22, 526, DateTimeKind.Utc), null, "DC Comics" },
                    { 2, new DateTime(1939, 10, 6, 17, 46, 22, 526, DateTimeKind.Utc), null, "Marvel Comics" },
                    { 3, new DateTime(1949, 10, 7, 8, 6, 3, 879, DateTimeKind.Utc), null, "Shueisha" }
                });

            migrationBuilder.InsertData(
                table: "Series",
                columns: new[] { "Id", "CicloNum", "EditoraId", "EstadoPubAtual", "NomeInter" },
                values: new object[,]
                {
                    { 1, 1, 1, "FINALIZADO", "The Dark Knight Returns" },
                    { 2, 1, 1, "FINALIZADO", "Watchmen" },
                    { 3, 1, 2, "EM ANDAMENTO", "Immortal Thor" },
                    { 4, 1, 2, "FINALIZADO", "Marvels" },
                    { 5, 1, 3, "EM ANDAMENTO", "One Punch-Man" }
                });

            migrationBuilder.InsertData(
                table: "Edicoes",
                columns: new[] { "Id", "DataLancamento", "FotoCapa", "Numero", "Preco", "SerieId", "UnMonetaria" },
                values: new object[,]
                {
                    { 3, new DateTime(1986, 3, 1, 13, 23, 50, 846, DateTimeKind.Utc), "https://robng-tcc-arquivos.s3.us-east-1.amazonaws.com/Batman_-_Dark_Knight_Returns/Batman_-_Dark_Knight_Returns_1/Batman_-_Dark_Knight_Returns_1.jpg", "1A", 2.95m, 1, "USD" },
                    { 7, new DateTime(2012, 12, 8, 15, 4, 13, 155, DateTimeKind.Utc), "https://robng-tcc-arquivos.s3.us-east-1.amazonaws.com/One_Punch_Man/OPM_1/OPM_1.png", "1", 440m, 5, "JPY" },
                    { 8, new DateTime(2012, 12, 4, 15, 4, 13, 155, DateTimeKind.Utc), "https://robng-tcc-arquivos.s3.us-east-1.amazonaws.com/One_Punch_Man/OPM_2/OPM_2.png", "2", 440m, 5, "JPY" },
                    { 9, new DateTime(2013, 4, 4, 14, 4, 13, 155, DateTimeKind.Utc), "https://robng-tcc-arquivos.s3.us-east-1.amazonaws.com/One_Punch_Man/OPM_3/OPM_3.png", "3", 440m, 5, "JPY" },
                    { 10, new DateTime(2013, 8, 2, 14, 4, 13, 155, DateTimeKind.Utc), "https://robng-tcc-arquivos.s3.us-east-1.amazonaws.com/One_Punch_Man/OPM_4/OPM_4.png", "4", 440m, 5, "JPY" },
                    { 11, new DateTime(2013, 12, 4, 15, 4, 13, 155, DateTimeKind.Utc), "https://robng-tcc-arquivos.s3.us-east-1.amazonaws.com/One_Punch_Man/OPM_5/OPM_5.png", "5", 440m, 5, "JPY" },
                    { 12, new DateTime(2014, 5, 2, 14, 4, 13, 155, DateTimeKind.Utc), "https://robng-tcc-arquivos.s3.us-east-1.amazonaws.com/One_Punch_Man/OPM_6/OPM_6.png", "6", 440m, 5, "JPY" },
                    { 13, new DateTime(2014, 12, 4, 15, 4, 13, 155, DateTimeKind.Utc), "https://robng-tcc-arquivos.s3.us-east-1.amazonaws.com/One_Punch_Man/OPM_7/OPM_7.png", "7", 440m, 5, "JPY" },
                    { 14, new DateTime(2015, 4, 3, 14, 4, 13, 155, DateTimeKind.Utc), "https://robng-tcc-arquivos.s3.us-east-1.amazonaws.com/One_Punch_Man/OPM_8/OPM_8.png", "8", 440m, 5, "JPY" },
                    { 15, new DateTime(2015, 8, 4, 14, 4, 13, 155, DateTimeKind.Utc), "https://robng-tcc-arquivos.s3.us-east-1.amazonaws.com/One_Punch_Man/OPM_9/OPM_9.png", "9", 440m, 5, "JPY" },
                    { 16, new DateTime(2015, 12, 4, 15, 4, 13, 155, DateTimeKind.Utc), "https://robng-tcc-arquivos.s3.us-east-1.amazonaws.com/One_Punch_Man/OPM_10/OPM_10.png", "10", 440m, 5, "JPY" },
                    { 17, new DateTime(1986, 4, 1, 16, 37, 26, 156, DateTimeKind.Utc), "https://robng-tcc-arquivos.s3.us-east-1.amazonaws.com/Batman_-_Dark_Knight_Returns/Batman_-_Dark_Knight_Returns_2/Batman_-_Dark_Knight_Returns_2.jpg", "2A", 2.95m, 1, "USD" },
                    { 18, new DateTime(1986, 5, 1, 16, 37, 26, 156, DateTimeKind.Utc), "https://robng-tcc-arquivos.s3.us-east-1.amazonaws.com/Batman_-_Dark_Knight_Returns/Batman_-_Dark_Knight_Returns_3/Batman_-_Dark_Knight_Returns_3.jpg", "3A", 2.95m, 1, "USD" },
                    { 19, new DateTime(1986, 6, 1, 16, 37, 26, 156, DateTimeKind.Utc), "https://robng-tcc-arquivos.s3.us-east-1.amazonaws.com/Batman_-_Dark_Knight_Returns/Batman_-_Dark_Knight_Returns_4/Batman_-_Dark_Knight_Returns_4.jpg", "4A", 2.95m, 1, "USD" },
                    { 20, new DateTime(1986, 9, 1, 16, 37, 26, 156, DateTimeKind.Utc), "https://robng-tcc-arquivos.s3.us-east-1.amazonaws.com/Watchmen_Vol_1/Watchmen_Vol_1_1/Watchmen_1.jpg", "1A", 1.50m, 2, "USD" },
                    { 21, new DateTime(1986, 10, 1, 16, 37, 26, 156, DateTimeKind.Utc), "https://robng-tcc-arquivos.s3.us-east-1.amazonaws.com/Watchmen_Vol_1/Watchmen_Vol_1_2/Watchmen_2.jpg", "2A", 1.50m, 2, "USD" },
                    { 22, new DateTime(1986, 11, 1, 16, 37, 26, 156, DateTimeKind.Utc), "https://robng-tcc-arquivos.s3.us-east-1.amazonaws.com/Watchmen_Vol_1/Watchmen_Vol_1_3/Watchmen_3.jpg", "3A", 1.50m, 2, "USD" },
                    { 23, new DateTime(1986, 12, 1, 17, 37, 26, 156, DateTimeKind.Utc), "https://robng-tcc-arquivos.s3.us-east-1.amazonaws.com/Watchmen_Vol_1/Watchmen_Vol_1_4/Watchmen_4.jpg", "4A", 1.50m, 2, "USD" },
                    { 24, new DateTime(1987, 1, 1, 17, 37, 26, 156, DateTimeKind.Utc), "https://robng-tcc-arquivos.s3.us-east-1.amazonaws.com/Watchmen_Vol_1/Watchmen_Vol_1_5/Watchmen_5.jpg", "5A", 1.50m, 2, "USD" },
                    { 25, new DateTime(1987, 2, 1, 17, 37, 26, 156, DateTimeKind.Utc), "https://robng-tcc-arquivos.s3.us-east-1.amazonaws.com/Watchmen_Vol_1/Watchmen_Vol_1_6/Watchmen_6.jpg", "6A", 1.50m, 2, "USD" },
                    { 26, new DateTime(1987, 3, 1, 16, 37, 26, 156, DateTimeKind.Utc), "https://robng-tcc-arquivos.s3.us-east-1.amazonaws.com/Watchmen_Vol_1/Watchmen_Vol_1_7/Watchmen_7.jpg", "7A", 1.50m, 2, "USD" },
                    { 27, new DateTime(1987, 4, 1, 16, 37, 26, 156, DateTimeKind.Utc), "https://robng-tcc-arquivos.s3.us-east-1.amazonaws.com/Watchmen_Vol_1/Watchmen_Vol_1_8/Watchmen_8.jpg", "8A", 1.50m, 2, "USD" },
                    { 29, new DateTime(1987, 5, 1, 16, 37, 26, 156, DateTimeKind.Utc), "https://robng-tcc-arquivos.s3.us-east-1.amazonaws.com/Watchmen_Vol_1/Watchmen_Vol_1_9/Watchmen_9.jpg", "9A", 1.50m, 2, "USD" },
                    { 30, new DateTime(1987, 7, 1, 16, 37, 26, 156, DateTimeKind.Utc), "https://robng-tcc-arquivos.s3.us-east-1.amazonaws.com/Watchmen_Vol_1/Watchmen_Vol_1_10/Watchmen_10.jpg", "10A", 1.50m, 2, "USD" },
                    { 31, new DateTime(1987, 8, 1, 16, 37, 26, 156, DateTimeKind.Utc), "https://robng-tcc-arquivos.s3.us-east-1.amazonaws.com/Watchmen_Vol_1/Watchmen_Vol_1_11/Watchmen_11.jpg", "11A", 1.50m, 2, "USD" },
                    { 32, new DateTime(1987, 10, 1, 16, 37, 26, 156, DateTimeKind.Utc), "https://robng-tcc-arquivos.s3.us-east-1.amazonaws.com/Watchmen_Vol_1/Watchmen_Vol_1_12/Watchmen_12.jpg", "12A", 1.50m, 2, "USD" },
                    { 33, new DateTime(1994, 1, 1, 17, 37, 26, 156, DateTimeKind.Utc), "https://robng-tcc-arquivos.s3.us-east-1.amazonaws.com/Marvels_Vol_1/Marvels_Vol_1_1/Marvels_Vol_1_1.jpg", "1A", 5.95m, 4, "USD" },
                    { 34, new DateTime(1994, 2, 1, 17, 37, 26, 156, DateTimeKind.Utc), "https://robng-tcc-arquivos.s3.us-east-1.amazonaws.com/Marvels_Vol_1/Marvels_Vol_1_2/Marvels_Vol_1_2.jpg", "2A", 5.95m, 4, "USD" },
                    { 35, new DateTime(1994, 3, 1, 16, 37, 26, 156, DateTimeKind.Utc), "https://robng-tcc-arquivos.s3.us-east-1.amazonaws.com/Marvels_Vol_1/Marvels_Vol_1_3/Marvels_Vol_1_3.jpg", "3A", 5.95m, 4, "USD" },
                    { 36, new DateTime(1994, 4, 1, 16, 37, 26, 156, DateTimeKind.Utc), "https://robng-tcc-arquivos.s3.us-east-1.amazonaws.com/Marvels_Vol_1/Marvels_Vol_1_4/Marvels_Vol_1_4.jpg", "4A", 5.95m, 4, "USD" },
                    { 37, new DateTime(2023, 10, 1, 16, 37, 26, 156, DateTimeKind.Utc), "https://robng-tcc-arquivos.s3.us-east-1.amazonaws.com/Immortal_Thor_Vol_1/Immortal_Thor_Vol_1_1/Immortal_Thor_Vol_1_1.jpg", "1A", 6.99m, 3, "USD" },
                    { 38, new DateTime(2023, 11, 1, 16, 37, 26, 156, DateTimeKind.Utc), "https://robng-tcc-arquivos.s3.us-east-1.amazonaws.com/Immortal_Thor_Vol_1/Immortal_Thor_Vol_1_2/Immortal_Thor_Vol_1_2.jpg", "2A", 4.99m, 3, "USD" },
                    { 39, new DateTime(2023, 12, 1, 16, 37, 26, 156, DateTimeKind.Utc), "https://robng-tcc-arquivos.s3.us-east-1.amazonaws.com/Immortal_Thor_Vol_1/Immortal_Thor_Vol_1_3/Immortal_Thor_Vol_1_3.jpg", "3A", 4.99m, 3, "USD" },
                    { 40, new DateTime(2024, 1, 1, 16, 37, 26, 156, DateTimeKind.Utc), "https://robng-tcc-arquivos.s3.us-east-1.amazonaws.com/Immortal_Thor_Vol_1/Immortal_Thor_Vol_1_4/Immortal_Thor_Vol_1_4.jpg", "4A", 4.99m, 3, "USD" },
                    { 41, new DateTime(2024, 2, 1, 16, 37, 26, 156, DateTimeKind.Utc), "https://robng-tcc-arquivos.s3.us-east-1.amazonaws.com/Immortal_Thor_Vol_1/Immortal_Thor_Vol_1_5/Immortal_Thor_Vol_1_5.jpg", "5A", 4.99m, 3, "USD" },
                    { 42, new DateTime(2024, 3, 1, 16, 37, 26, 156, DateTimeKind.Utc), "https://robng-tcc-arquivos.s3.us-east-1.amazonaws.com/Immortal_Thor_Vol_1/Immortal_Thor_Vol_1_6/Immortal_Thor_Vol_1_6.jpg", "6A", 4.99m, 3, "USD" },
                    { 43, new DateTime(2024, 4, 1, 16, 37, 26, 156, DateTimeKind.Utc), "https://robng-tcc-arquivos.s3.us-east-1.amazonaws.com/Immortal_Thor_Vol_1/Immortal_Thor_Vol_1_7/Immortal_Thor_Vol_1_7.jpg", "7A", 4.99m, 3, "USD" },
                    { 44, new DateTime(2024, 5, 1, 16, 37, 26, 156, DateTimeKind.Utc), "https://robng-tcc-arquivos.s3.us-east-1.amazonaws.com/Immortal_Thor_Vol_1/Immortal_Thor_Vol_1_8/Immortal_Thor_Vol_1_8.jpg", "8A", 4.99m, 3, "USD" },
                    { 45, new DateTime(2024, 6, 1, 16, 37, 26, 156, DateTimeKind.Utc), "https://robng-tcc-arquivos.s3.us-east-1.amazonaws.com/Immortal_Thor_Vol_1/Immortal_Thor_Vol_1_9/Immortal_Thor_Vol_1_9.jpg", "9A", 4.99m, 3, "USD" },
                    { 46, new DateTime(2024, 7, 1, 16, 37, 26, 156, DateTimeKind.Utc), "https://robng-tcc-arquivos.s3.us-east-1.amazonaws.com/Immortal_Thor_Vol_1/Immortal_Thor_Vol_1_10/Immortal_Thor_Vol_1_10.jpg", "10A", 4.99m, 3, "USD" },
                    { 47, new DateTime(2024, 7, 1, 16, 37, 26, 156, DateTimeKind.Utc), "https://robng-tcc-arquivos.s3.us-east-1.amazonaws.com/Immortal_Thor_Vol_1/Immortal_Thor_Vol_1_11/Immortal_Thor_Vol_1_11.jpg", "11A", 4.99m, 3, "USD" },
                    { 48, new DateTime(2024, 8, 1, 16, 37, 26, 156, DateTimeKind.Utc), "https://robng-tcc-arquivos.s3.us-east-1.amazonaws.com/Immortal_Thor_Vol_1/Immortal_Thor_Vol_1_12/Immortal_Thor_Vol_1_12.jpg", "12A", 4.99m, 3, "USD" },
                    { 49, new DateTime(2024, 10, 1, 16, 37, 26, 156, DateTimeKind.Utc), "https://robng-tcc-arquivos.s3.us-east-1.amazonaws.com/Immortal_Thor_Vol_1/Immortal_Thor_Vol_1_13/Immortal_Thor_Vol_1_13.jpg", "13A", 4.99m, 3, "USD" },
                    { 50, new DateTime(2024, 10, 1, 16, 37, 26, 156, DateTimeKind.Utc), "https://robng-tcc-arquivos.s3.us-east-1.amazonaws.com/Immortal_Thor_Vol_1/Immortal_Thor_Vol_1_14/Immortal_Thor_Vol_1_14.jpg", "14A", 4.99m, 3, "USD" }
                });

            migrationBuilder.InsertData(
                table: "Generos",
                columns: new[] { "Id", "SerieId", "Tipo" },
                values: new object[,]
                {
                    { 1, 1, "Drama" },
                    { 2, 5, "Ação" },
                    { 3, 2, "Drama" },
                    { 4, 3, "Fantasia" },
                    { 5, 4, "Drama" }
                });

            migrationBuilder.InsertData(
                table: "Mangas",
                columns: new[] { "Id", "Demografia", "NomeJap", "SerieId" },
                values: new object[] { 1, "Seinen", "ワンパンマン", 5 });

            migrationBuilder.InsertData(
                table: "Contribui",
                columns: new[] { "ContribuidorId", "EdicaoId", "Funcao" },
                values: new object[,]
                {
                    { 1, 3, "Desenhista" },
                    { 1, 3, "Roteirista" },
                    { 1, 17, "Desenhista" },
                    { 1, 17, "Roteirista" },
                    { 1, 18, "Desenhista" },
                    { 1, 18, "Roteirista" },
                    { 1, 19, "Desenhista" },
                    { 1, 19, "Roteirista" },
                    { 2, 20, "Roteirista" },
                    { 2, 21, "Roteirista" },
                    { 2, 22, "Roteirista" },
                    { 2, 23, "Roteirista" },
                    { 2, 24, "Roteirista" },
                    { 2, 25, "Roteirista" },
                    { 2, 26, "Roteirista" },
                    { 2, 27, "Roteirista" },
                    { 2, 29, "Roteirista" },
                    { 2, 30, "Roteirista" },
                    { 2, 31, "Roteirista" },
                    { 2, 32, "Roteirista" },
                    { 3, 20, "Roteirista" },
                    { 3, 21, "Roteirista" },
                    { 3, 22, "Roteirista" },
                    { 3, 23, "Roteirista" },
                    { 3, 24, "Roteirista" },
                    { 3, 25, "Roteirista" },
                    { 3, 26, "Roteirista" },
                    { 3, 27, "Roteirista" },
                    { 3, 29, "Roteirista" },
                    { 3, 30, "Roteirista" },
                    { 3, 31, "Roteirista" },
                    { 3, 32, "Roteirista" },
                    { 5, 7, "Mangaka" },
                    { 5, 8, "Mangaka" },
                    { 5, 9, "Mangaka" },
                    { 5, 10, "Mangaka" },
                    { 5, 11, "Mangaka" },
                    { 5, 12, "Mangaka" },
                    { 5, 13, "Mangaka" },
                    { 5, 14, "Mangaka" },
                    { 5, 15, "Mangaka" },
                    { 5, 16, "Mangaka" },
                    { 6, 37, "Roteirista" },
                    { 6, 38, "Roteirista" },
                    { 6, 39, "Roteirista" },
                    { 6, 40, "Roteirista" },
                    { 6, 41, "Roteirista" },
                    { 6, 42, "Roteirista" },
                    { 6, 43, "Roteirista" },
                    { 6, 44, "Roteirista" },
                    { 6, 45, "Roteirista" },
                    { 6, 46, "Roteirista" },
                    { 6, 47, "Roteirista" },
                    { 6, 48, "Roteirista" },
                    { 6, 49, "Roteirista" },
                    { 6, 50, "Roteirista" },
                    { 7, 37, "Desenhista" },
                    { 7, 38, "Desenhista" },
                    { 7, 39, "Desenhista" },
                    { 7, 40, "Desenhista" },
                    { 7, 41, "Desenhista" },
                    { 7, 42, "Desenhista" },
                    { 7, 43, "Desenhista" },
                    { 8, 44, "Desenhista" },
                    { 8, 45, "Desenhista" },
                    { 9, 46, "Desenhista" },
                    { 10, 47, "Desenhista" },
                    { 10, 48, "Desenhista" },
                    { 11, 49, "Desenhista" },
                    { 11, 50, "Desenhista" },
                    { 12, 33, "Roteirista" },
                    { 12, 34, "Roteirista" },
                    { 12, 35, "Roteirista" },
                    { 12, 36, "Roteirista" },
                    { 13, 33, "Desenhista" },
                    { 13, 34, "Desenhista" },
                    { 13, 35, "Desenhista" },
                    { 13, 36, "Desenhista" }
                });

            migrationBuilder.InsertData(
                table: "Tankobons",
                columns: new[] { "Id", "EdicaoId", "NumeroCapitulos" },
                values: new object[,]
                {
                    { 1, 7, 8 },
                    { 2, 8, 5 },
                    { 3, 9, 8 },
                    { 4, 10, 6 },
                    { 5, 11, 7 },
                    { 6, 12, 8 },
                    { 7, 13, 8 },
                    { 8, 14, 8 },
                    { 9, 15, 8 },
                    { 10, 16, 11 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Colecoes_AppUserId",
                table: "Colecoes",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Colecoes_NomeColecao",
                table: "Colecoes",
                column: "NomeColecao",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contribui_EdicaoId",
                table: "Contribui",
                column: "EdicaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Contribuidores_Nome_DataNasc",
                table: "Contribuidores",
                columns: new[] { "Nome", "DataNasc" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Edicoes_Numero_DataLancamento_SerieId",
                table: "Edicoes",
                columns: new[] { "Numero", "DataLancamento", "SerieId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Edicoes_SerieId",
                table: "Edicoes",
                column: "SerieId");

            migrationBuilder.CreateIndex(
                name: "IX_Editoras_AnoCriacao_Nome",
                table: "Editoras",
                columns: new[] { "AnoCriacao", "Nome" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Exemplares_ColecaoId",
                table: "Exemplares",
                column: "ColecaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Exemplares_EdicaoId",
                table: "Exemplares",
                column: "EdicaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Generos_SerieId",
                table: "Generos",
                column: "SerieId");

            migrationBuilder.CreateIndex(
                name: "IX_Generos_Tipo_SerieId",
                table: "Generos",
                columns: new[] { "Tipo", "SerieId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Mangas_SerieId",
                table: "Mangas",
                column: "SerieId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Series_EditoraId",
                table: "Series",
                column: "EditoraId");

            migrationBuilder.CreateIndex(
                name: "IX_Series_NomeInter_CicloNum_EditoraId",
                table: "Series",
                columns: new[] { "NomeInter", "CicloNum", "EditoraId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tankobons_EdicaoId",
                table: "Tankobons",
                column: "EdicaoId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Contribui");

            migrationBuilder.DropTable(
                name: "Exemplares");

            migrationBuilder.DropTable(
                name: "Generos");

            migrationBuilder.DropTable(
                name: "Mangas");

            migrationBuilder.DropTable(
                name: "Tankobons");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Contribuidores");

            migrationBuilder.DropTable(
                name: "Colecoes");

            migrationBuilder.DropTable(
                name: "Edicoes");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Series");

            migrationBuilder.DropTable(
                name: "Editoras");
        }
    }
}
