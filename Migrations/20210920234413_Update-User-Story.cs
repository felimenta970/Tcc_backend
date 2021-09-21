using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tcc_backend.Migrations
{
    public partial class UpdateUserStory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "UserStory",
                newName: "WhyDesc");

            migrationBuilder.AddColumn<string>(
                name: "WhatDesc",
                table: "UserStory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WhoDesc",
                table: "UserStory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "InitialDate",
                table: "Projeto",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 20, 20, 44, 12, 847, DateTimeKind.Local).AddTicks(6070),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 12, 23, 11, 29, 397, DateTimeKind.Local).AddTicks(7762));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WhatDesc",
                table: "UserStory");

            migrationBuilder.DropColumn(
                name: "WhoDesc",
                table: "UserStory");

            migrationBuilder.RenameColumn(
                name: "WhyDesc",
                table: "UserStory",
                newName: "Description");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InitialDate",
                table: "Projeto",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 12, 23, 11, 29, 397, DateTimeKind.Local).AddTicks(7762),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 20, 20, 44, 12, 847, DateTimeKind.Local).AddTicks(6070));
        }
    }
}
