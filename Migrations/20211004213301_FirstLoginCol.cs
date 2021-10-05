using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tcc_backend.Migrations
{
    public partial class FirstLoginCol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "InitialDate",
                table: "Projeto",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 4, 18, 33, 0, 872, DateTimeKind.Local).AddTicks(728),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 27, 20, 24, 6, 131, DateTimeKind.Local).AddTicks(9628));

            migrationBuilder.AddColumn<bool>(
                name: "IsFirstLogin",
                table: "Membro",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFirstLogin",
                table: "Membro");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InitialDate",
                table: "Projeto",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 27, 20, 24, 6, 131, DateTimeKind.Local).AddTicks(9628),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 4, 18, 33, 0, 872, DateTimeKind.Local).AddTicks(728));
        }
    }
}
