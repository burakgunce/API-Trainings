using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HastaneApi.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hastaneler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HastaneAd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HastaneAdres = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hastaneler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hastalar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Soyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Klinik = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MuayeneTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HastaneId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hastalar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hastalar_Hastaneler_HastaneId",
                        column: x => x.HastaneId,
                        principalTable: "Hastaneler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Hastaneler",
                columns: new[] { "Id", "HastaneAd", "HastaneAdres" },
                values: new object[] { 1, "Academic", "Uskudar" });

            migrationBuilder.InsertData(
                table: "Hastaneler",
                columns: new[] { "Id", "HastaneAd", "HastaneAdres" },
                values: new object[] { 2, "Acıbadem", "kadıkoy" });

            migrationBuilder.InsertData(
                table: "Hastalar",
                columns: new[] { "Id", "Ad", "HastaneId", "Klinik", "MuayeneTarihi", "Soyad" },
                values: new object[] { 1, "aaa", 1, "kbb", new DateTime(2024, 1, 25, 14, 35, 22, 159, DateTimeKind.Local).AddTicks(8542), "bbb" });

            migrationBuilder.InsertData(
                table: "Hastalar",
                columns: new[] { "Id", "Ad", "HastaneId", "Klinik", "MuayeneTarihi", "Soyad" },
                values: new object[] { 2, "ccc", 2, "ortopedi", new DateTime(2024, 1, 25, 14, 35, 22, 159, DateTimeKind.Local).AddTicks(8551), "ddd" });

            migrationBuilder.CreateIndex(
                name: "IX_Hastalar_HastaneId",
                table: "Hastalar",
                column: "HastaneId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hastalar");

            migrationBuilder.DropTable(
                name: "Hastaneler");
        }
    }
}
