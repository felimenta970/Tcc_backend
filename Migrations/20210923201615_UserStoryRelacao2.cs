using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tcc_backend.Migrations
{
    public partial class UserStoryRelacao2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "InitialDate",
                table: "Projeto",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 23, 17, 16, 14, 724, DateTimeKind.Local).AddTicks(7250),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 23, 17, 15, 38, 536, DateTimeKind.Local).AddTicks(567));

            migrationBuilder.CreateTable(
                name: "RelacaoUserStories",
                columns: table => new
                {
                    RelacaoUserStoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HistoriaUsuarioPaiID = table.Column<int>(type: "int", nullable: false),
                    HistoriaUsuarioFilhoID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelacaoUserStories", x => x.RelacaoUserStoryID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RelacaoUserStories");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InitialDate",
                table: "Projeto",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 23, 17, 15, 38, 536, DateTimeKind.Local).AddTicks(567),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 23, 17, 16, 14, 724, DateTimeKind.Local).AddTicks(7250));
        }
    }
}
