using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace car_webapi.Migrations
{
    public partial class InitialDbSetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Felgen",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: false),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Felgen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lackierung",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: false),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lackierung", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Motor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: false),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sonderausstattung",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: false),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sonderausstattung", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Auftrag",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false),
                    MotorId = table.Column<int>(nullable: false),
                    LackierungId = table.Column<int>(nullable: false),
                    FelgenId = table.Column<int>(nullable: false),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    TotalPrice = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auftrag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Auftrag_Felgen_FelgenId",
                        column: x => x.FelgenId,
                        principalTable: "Felgen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Auftrag_Lackierung_LackierungId",
                        column: x => x.LackierungId,
                        principalTable: "Lackierung",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Auftrag_Motor_MotorId",
                        column: x => x.MotorId,
                        principalTable: "Motor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exclusion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SonderausstattungId = table.Column<int>(nullable: false),
                    Cannot = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exclusion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exclusion_Sonderausstattung_SonderausstattungId",
                        column: x => x.SonderausstattungId,
                        principalTable: "Sonderausstattung",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ausstattung",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuftragId = table.Column<int>(nullable: false),
                    SonderausstattungId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ausstattung", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ausstattung_Auftrag_AuftragId",
                        column: x => x.AuftragId,
                        principalTable: "Auftrag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ausstattung_Sonderausstattung_SonderausstattungId",
                        column: x => x.SonderausstattungId,
                        principalTable: "Sonderausstattung",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Auftrag_FelgenId",
                table: "Auftrag",
                column: "FelgenId");

            migrationBuilder.CreateIndex(
                name: "IX_Auftrag_LackierungId",
                table: "Auftrag",
                column: "LackierungId");

            migrationBuilder.CreateIndex(
                name: "IX_Auftrag_MotorId",
                table: "Auftrag",
                column: "MotorId");

            migrationBuilder.CreateIndex(
                name: "IX_Ausstattung_AuftragId",
                table: "Ausstattung",
                column: "AuftragId");

            migrationBuilder.CreateIndex(
                name: "IX_Ausstattung_SonderausstattungId",
                table: "Ausstattung",
                column: "SonderausstattungId");

            migrationBuilder.CreateIndex(
                name: "IX_Exclusion_SonderausstattungId",
                table: "Exclusion",
                column: "SonderausstattungId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ausstattung");

            migrationBuilder.DropTable(
                name: "Exclusion");

            migrationBuilder.DropTable(
                name: "Auftrag");

            migrationBuilder.DropTable(
                name: "Sonderausstattung");

            migrationBuilder.DropTable(
                name: "Felgen");

            migrationBuilder.DropTable(
                name: "Lackierung");

            migrationBuilder.DropTable(
                name: "Motor");
        }
    }
}
