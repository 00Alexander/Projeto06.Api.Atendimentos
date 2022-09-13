using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto06.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Servicos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Atendimento",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Hora = table.Column<TimeSpan>(type: "time", nullable: true),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    Observacoes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atendimento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Atendimento_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AtendimentoServico",
                columns: table => new
                {
                    AtendimentoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServicoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtendimentoServico", x => new { x.AtendimentoId, x.ServicoId });
                    table.ForeignKey(
                        name: "FK_AtendimentoServico_Atendimento_AtendimentoId",
                        column: x => x.AtendimentoId,
                        principalTable: "Atendimento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AtendimentoServico_Servicos_ServicoId",
                        column: x => x.ServicoId,
                        principalTable: "Servicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Atendimento_ClienteId",
                table: "Atendimento",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_AtendimentoServico_ServicoId",
                table: "AtendimentoServico",
                column: "ServicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_Email",
                table: "Cliente",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_Telefone",
                table: "Cliente",
                column: "Telefone",
                unique: true,
                filter: "[Telefone] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Servicos_Nome",
                table: "Servicos",
                column: "Nome",
                unique: true,
                filter: "[Nome] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AtendimentoServico");

            migrationBuilder.DropTable(
                name: "Atendimento");

            migrationBuilder.DropTable(
                name: "Servicos");

            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
