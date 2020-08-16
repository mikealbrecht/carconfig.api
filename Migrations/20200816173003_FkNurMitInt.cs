using Microsoft.EntityFrameworkCore.Migrations;

namespace car_webapi.Migrations
{
    public partial class FkNurMitInt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Auftrag_Felgen_FelgenId",
                table: "Auftrag");

            migrationBuilder.DropForeignKey(
                name: "FK_Auftrag_Lackierung_LackierungId",
                table: "Auftrag");

            migrationBuilder.DropForeignKey(
                name: "FK_Auftrag_Motor_MotorId",
                table: "Auftrag");

            migrationBuilder.DropForeignKey(
                name: "FK_Ausstattung_Auftrag_AuftragId",
                table: "Ausstattung");

            migrationBuilder.DropForeignKey(
                name: "FK_Ausstattung_Sonderausstattung_SonderausstattungId",
                table: "Ausstattung");

            migrationBuilder.DropForeignKey(
                name: "FK_Exclusion_Sonderausstattung_SonderausstattungId",
                table: "Exclusion");

            migrationBuilder.DropIndex(
                name: "IX_Exclusion_SonderausstattungId",
                table: "Exclusion");

            migrationBuilder.DropIndex(
                name: "IX_Ausstattung_AuftragId",
                table: "Ausstattung");

            migrationBuilder.DropIndex(
                name: "IX_Ausstattung_SonderausstattungId",
                table: "Ausstattung");

            migrationBuilder.DropIndex(
                name: "IX_Auftrag_FelgenId",
                table: "Auftrag");

            migrationBuilder.DropIndex(
                name: "IX_Auftrag_LackierungId",
                table: "Auftrag");

            migrationBuilder.DropIndex(
                name: "IX_Auftrag_MotorId",
                table: "Auftrag");

            migrationBuilder.DropColumn(
                name: "SonderausstattungId",
                table: "Exclusion");

            migrationBuilder.DropColumn(
                name: "AuftragId",
                table: "Ausstattung");

            migrationBuilder.DropColumn(
                name: "SonderausstattungId",
                table: "Ausstattung");

            migrationBuilder.DropColumn(
                name: "FelgenId",
                table: "Auftrag");

            migrationBuilder.DropColumn(
                name: "LackierungId",
                table: "Auftrag");

            migrationBuilder.DropColumn(
                name: "MotorId",
                table: "Auftrag");

            migrationBuilder.AddColumn<int>(
                name: "Sonderausstattung",
                table: "Exclusion",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Auftrag",
                table: "Ausstattung",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Sonderausstattung",
                table: "Ausstattung",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Felgen",
                table: "Auftrag",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Lackierung",
                table: "Auftrag",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Motor",
                table: "Auftrag",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sonderausstattung",
                table: "Exclusion");

            migrationBuilder.DropColumn(
                name: "Auftrag",
                table: "Ausstattung");

            migrationBuilder.DropColumn(
                name: "Sonderausstattung",
                table: "Ausstattung");

            migrationBuilder.DropColumn(
                name: "Felgen",
                table: "Auftrag");

            migrationBuilder.DropColumn(
                name: "Lackierung",
                table: "Auftrag");

            migrationBuilder.DropColumn(
                name: "Motor",
                table: "Auftrag");

            migrationBuilder.AddColumn<int>(
                name: "SonderausstattungId",
                table: "Exclusion",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AuftragId",
                table: "Ausstattung",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SonderausstattungId",
                table: "Ausstattung",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FelgenId",
                table: "Auftrag",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LackierungId",
                table: "Auftrag",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MotorId",
                table: "Auftrag",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Exclusion_SonderausstattungId",
                table: "Exclusion",
                column: "SonderausstattungId");

            migrationBuilder.CreateIndex(
                name: "IX_Ausstattung_AuftragId",
                table: "Ausstattung",
                column: "AuftragId");

            migrationBuilder.CreateIndex(
                name: "IX_Ausstattung_SonderausstattungId",
                table: "Ausstattung",
                column: "SonderausstattungId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Auftrag_Felgen_FelgenId",
                table: "Auftrag",
                column: "FelgenId",
                principalTable: "Felgen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Auftrag_Lackierung_LackierungId",
                table: "Auftrag",
                column: "LackierungId",
                principalTable: "Lackierung",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Auftrag_Motor_MotorId",
                table: "Auftrag",
                column: "MotorId",
                principalTable: "Motor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ausstattung_Auftrag_AuftragId",
                table: "Ausstattung",
                column: "AuftragId",
                principalTable: "Auftrag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ausstattung_Sonderausstattung_SonderausstattungId",
                table: "Ausstattung",
                column: "SonderausstattungId",
                principalTable: "Sonderausstattung",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Exclusion_Sonderausstattung_SonderausstattungId",
                table: "Exclusion",
                column: "SonderausstattungId",
                principalTable: "Sonderausstattung",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
