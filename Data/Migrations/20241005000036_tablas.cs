using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ExamenParcial.Data.Migrations
{
    /// <inheritdoc />
    public partial class tablas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "t_conversion",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MonedaOrigen = table.Column<string>(type: "text", nullable: true),
                    MonedaDestino = table.Column<string>(type: "text", nullable: true),
                    TasaCambio = table.Column<decimal>(type: "numeric", nullable: true),
                    Fecha = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_conversion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "t_remesa",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Remitente = table.Column<string>(type: "text", nullable: true),
                    Destinatario = table.Column<string>(type: "text", nullable: true),
                    PaisOrigen = table.Column<string>(type: "text", nullable: true),
                    PaisDestino = table.Column<string>(type: "text", nullable: true),
                    MontoEnviado = table.Column<decimal>(type: "numeric", nullable: true),
                    Moneda = table.Column<string>(type: "text", nullable: true),
                    TasaCambio = table.Column<decimal>(type: "numeric", nullable: true),
                    MontoRecibido = table.Column<decimal>(type: "numeric", nullable: true),
                    EstadoTransaccion = table.Column<string>(type: "text", nullable: true),
                    FechaTransaccion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UsuarioID = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_remesa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_t_remesa_AspNetUsers_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_t_remesa_UsuarioID",
                table: "t_remesa",
                column: "UsuarioID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
