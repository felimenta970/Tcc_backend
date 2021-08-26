using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tcc_backend.Migrations
{
    public partial class Initial_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "InitialDate",
                table: "Projeto",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 26, 0, 11, 44, 746, DateTimeKind.Local).AddTicks(8785),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 26, 0, 8, 33, 203, DateTimeKind.Local).AddTicks(3132));

            migrationBuilder.CreateIndex(
                name: "IX_Mudanca_ProjectManagerID",
                table: "Mudanca",
                column: "ProjectManagerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Mudanca_ProjectManagerID",
                table: "Mudanca");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InitialDate",
                table: "Projeto",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 26, 0, 8, 33, 203, DateTimeKind.Local).AddTicks(3132),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 26, 0, 11, 44, 746, DateTimeKind.Local).AddTicks(8785));

        }
    }
}
