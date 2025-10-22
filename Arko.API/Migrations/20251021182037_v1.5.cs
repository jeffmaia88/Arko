using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Arko.API.Migrations
{
    /// <inheritdoc />
    public partial class v15 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Analistas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Analistas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Equipamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Patrimony = table.Column<string>(type: "VARCHAR(64)", maxLength: 64, nullable: false),
                    Type = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    Brand = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    Model = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipamentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Baixa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateDischarge = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EquipmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Baixa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Baixa_Equipamentos_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Entradas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Origin = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    EntryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdEquipment = table.Column<int>(type: "int", nullable: false),
                    IdAnalyst = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entradas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Entradas_Analistas_IdAnalyst",
                        column: x => x.IdAnalyst,
                        principalTable: "Analistas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Entradas_Equipamentos_IdEquipment",
                        column: x => x.IdEquipment,
                        principalTable: "Equipamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EstoqueAtual",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(type: "int", nullable: false),
                    EquipmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstoqueAtual", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EstoqueAtual_Equipamentos_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Saidas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Destination = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    ExitDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdEquipment = table.Column<int>(type: "int", nullable: false),
                    IdAnalyst = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Saidas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Saidas_Analistas_IdAnalyst",
                        column: x => x.IdAnalyst,
                        principalTable: "Analistas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Saidas_Equipamentos_IdEquipment",
                        column: x => x.IdEquipment,
                        principalTable: "Equipamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Baixa_EquipmentId",
                table: "Baixa",
                column: "EquipmentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Entradas_IdAnalyst",
                table: "Entradas",
                column: "IdAnalyst");

            migrationBuilder.CreateIndex(
                name: "IX_Entradas_IdEquipment",
                table: "Entradas",
                column: "IdEquipment");

            migrationBuilder.CreateIndex(
                name: "IX_EstoqueAtual_EquipmentId",
                table: "EstoqueAtual",
                column: "EquipmentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Saidas_IdAnalyst",
                table: "Saidas",
                column: "IdAnalyst");

            migrationBuilder.CreateIndex(
                name: "IX_Saidas_IdEquipment",
                table: "Saidas",
                column: "IdEquipment");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Baixa");

            migrationBuilder.DropTable(
                name: "Entradas");

            migrationBuilder.DropTable(
                name: "EstoqueAtual");

            migrationBuilder.DropTable(
                name: "Saidas");

            migrationBuilder.DropTable(
                name: "Analistas");

            migrationBuilder.DropTable(
                name: "Equipamentos");
        }
    }
}
