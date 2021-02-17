using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "checklists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarroLimpo = table.Column<bool>(type: "bit", nullable: false),
                    TanqueCheio = table.Column<bool>(type: "bit", nullable: false),
                    TanqueLitroPendent = table.Column<int>(type: "int", nullable: false),
                    Amassados = table.Column<bool>(type: "bit", nullable: false),
                    Arranhoes = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_checklists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "models",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_models", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Documento = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Aniversario = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cep = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Logradouro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Complemento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Uf = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Placa = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    Ano = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValorHora = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LimitePorMalas = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Combustivel = table.Column<int>(type: "int", nullable: false),
                    IdMarca = table.Column<int>(type: "int", nullable: false),
                    IdModelo = table.Column<int>(type: "int", nullable: false),
                    IdCategoria = table.Column<int>(type: "int", nullable: false),
                    IdVeiculo = table.Column<int>(type: "int", nullable: false),
                    veiculoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cars_brands_IdMarca",
                        column: x => x.IdMarca,
                        principalTable: "brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cars_cars_veiculoId",
                        column: x => x.veiculoId,
                        principalTable: "cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_cars_categories_IdCategoria",
                        column: x => x.IdCategoria,
                        principalTable: "categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cars_models_IdModelo",
                        column: x => x.IdModelo,
                        principalTable: "models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "schedule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataAgendamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataColetaPrevista = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataColetaRealizada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataEntregaPrevista = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataEntregaRealizada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValorHora = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HorasLocacao = table.Column<double>(type: "float", nullable: false),
                    SubTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CustosAdicionais = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RealizadaVistoria = table.Column<bool>(type: "bit", nullable: false),
                    IdPessoa = table.Column<int>(type: "int", nullable: false),
                    IdVeiculo = table.Column<int>(type: "int", nullable: false),
                    IdChecklist = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_schedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_schedule_cars_IdVeiculo",
                        column: x => x.IdVeiculo,
                        principalTable: "cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_schedule_checklists_IdChecklist",
                        column: x => x.IdChecklist,
                        principalTable: "checklists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_schedule_users_IdPessoa",
                        column: x => x.IdPessoa,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cars_IdCategoria",
                table: "cars",
                column: "IdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_cars_IdMarca",
                table: "cars",
                column: "IdMarca");

            migrationBuilder.CreateIndex(
                name: "IX_cars_IdModelo",
                table: "cars",
                column: "IdModelo");

            migrationBuilder.CreateIndex(
                name: "IX_cars_veiculoId",
                table: "cars",
                column: "veiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_schedule_IdChecklist",
                table: "schedule",
                column: "IdChecklist",
                unique: true,
                filter: "[IdChecklist] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_schedule_IdPessoa",
                table: "schedule",
                column: "IdPessoa");

            migrationBuilder.CreateIndex(
                name: "IX_schedule_IdVeiculo",
                table: "schedule",
                column: "IdVeiculo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "schedule");

            migrationBuilder.DropTable(
                name: "cars");

            migrationBuilder.DropTable(
                name: "checklists");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "brands");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "models");
        }
    }
}
