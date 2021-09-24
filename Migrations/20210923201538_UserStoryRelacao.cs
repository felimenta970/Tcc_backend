using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tcc_backend.Migrations
{
    public partial class UserStoryRelacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "InitialDate",
                table: "Projeto",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 23, 17, 15, 38, 536, DateTimeKind.Local).AddTicks(567),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 20, 20, 44, 12, 847, DateTimeKind.Local).AddTicks(6070));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "InitialDate",
                table: "Projeto",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 20, 20, 44, 12, 847, DateTimeKind.Local).AddTicks(6070),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 23, 17, 15, 38, 536, DateTimeKind.Local).AddTicks(567));
        }
    }
}
