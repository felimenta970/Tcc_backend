using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tcc_backend.Migrations
{
    public partial class UserStoryFixTeste1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserStory_Sprint_SprintID",
                table: "UserStory");

            migrationBuilder.AlterColumn<int>(
                name: "SprintID",
                table: "UserStory",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InitialDate",
                table: "Projeto",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 23, 17, 39, 42, 92, DateTimeKind.Local).AddTicks(4796),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 23, 17, 16, 14, 724, DateTimeKind.Local).AddTicks(7250));

            migrationBuilder.AddForeignKey(
                name: "FK_UserStory_Sprint_SprintID",
                table: "UserStory",
                column: "SprintID",
                principalTable: "Sprint",
                principalColumn: "SprintID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserStory_Sprint_SprintID",
                table: "UserStory");

            migrationBuilder.AlterColumn<int>(
                name: "SprintID",
                table: "UserStory",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "InitialDate",
                table: "Projeto",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 23, 17, 16, 14, 724, DateTimeKind.Local).AddTicks(7250),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 23, 17, 39, 42, 92, DateTimeKind.Local).AddTicks(4796));

            migrationBuilder.AddForeignKey(
                name: "FK_UserStory_Sprint_SprintID",
                table: "UserStory",
                column: "SprintID",
                principalTable: "Sprint",
                principalColumn: "SprintID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
