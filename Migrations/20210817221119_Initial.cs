using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tcc_backend.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Membro",
                columns: table => new
                {
                    MembroID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Membro", x => x.MembroID);
                });

            migrationBuilder.CreateTable(
                name: "ProjectManager",
                columns: table => new
                {
                    ProjectManagerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectManager", x => x.ProjectManagerID);
                });

            migrationBuilder.CreateTable(
                name: "Projeto",
                columns: table => new
                {
                    ProjetoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InitialDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UrlGit = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projeto", x => x.ProjetoID);
                });

            migrationBuilder.CreateTable(
                name: "Sprint",
                columns: table => new
                {
                    SprintID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjetoID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sprint", x => x.SprintID);
                    table.ForeignKey(
                        name: "FK_Sprint_Projeto_ProjetoID",
                        column: x => x.ProjetoID,
                        principalTable: "Projeto",
                        principalColumn: "ProjetoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserStory",
                columns: table => new
                {
                    UserStoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MembroID = table.Column<int>(type: "int", nullable: false),
                    ProjectManagerID = table.Column<int>(type: "int", nullable: false),
                    SprintID = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ProjetoID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserStory", x => x.UserStoryID);
                    table.ForeignKey(
                        name: "FK_UserStory_Membro_MembroID",
                        column: x => x.MembroID,
                        principalTable: "Membro",
                        principalColumn: "MembroID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserStory_ProjectManager_ProjectManagerID",
                        column: x => x.ProjectManagerID,
                        principalTable: "ProjectManager",
                        principalColumn: "ProjectManagerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserStory_Projeto_ProjetoID",
                        column: x => x.ProjetoID,
                        principalTable: "Projeto",
                        principalColumn: "ProjetoID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserStory_Sprint_SprintID",
                        column: x => x.SprintID,
                        principalTable: "Sprint",
                        principalColumn: "SprintID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Anexo",
                columns: table => new
                {
                    AnexoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoAnexo = table.Column<int>(type: "int", nullable: false),
                    UserStoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anexo", x => x.AnexoID);
                    table.ForeignKey(
                        name: "FK_Anexo_UserStory_UserStoryID",
                        column: x => x.UserStoryID,
                        principalTable: "UserStory",
                        principalColumn: "UserStoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Commit",
                columns: table => new
                {
                    CommitID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserStoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commit", x => x.CommitID);
                    table.ForeignKey(
                        name: "FK_Commit_UserStory_UserStoryID",
                        column: x => x.UserStoryID,
                        principalTable: "UserStory",
                        principalColumn: "UserStoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mudanca",
                columns: table => new
                {
                    MudancaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserStoryID = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataModificacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mudanca", x => x.MudancaID);
                    table.ForeignKey(
                        name: "FK_Mudanca_UserStory_UserStoryID",
                        column: x => x.UserStoryID,
                        principalTable: "UserStory",
                        principalColumn: "UserStoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Anexo_UserStoryID",
                table: "Anexo",
                column: "UserStoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Commit_UserStoryID",
                table: "Commit",
                column: "UserStoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Mudanca_UserStoryID",
                table: "Mudanca",
                column: "UserStoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Sprint_ProjetoID",
                table: "Sprint",
                column: "ProjetoID");

            migrationBuilder.CreateIndex(
                name: "IX_UserStory_MembroID",
                table: "UserStory",
                column: "MembroID");

            migrationBuilder.CreateIndex(
                name: "IX_UserStory_ProjectManagerID",
                table: "UserStory",
                column: "ProjectManagerID");

            migrationBuilder.CreateIndex(
                name: "IX_UserStory_ProjetoID",
                table: "UserStory",
                column: "ProjetoID");

            migrationBuilder.CreateIndex(
                name: "IX_UserStory_SprintID",
                table: "UserStory",
                column: "SprintID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Anexo");

            migrationBuilder.DropTable(
                name: "Commit");

            migrationBuilder.DropTable(
                name: "Mudanca");

            migrationBuilder.DropTable(
                name: "UserStory");

            migrationBuilder.DropTable(
                name: "Membro");

            migrationBuilder.DropTable(
                name: "ProjectManager");

            migrationBuilder.DropTable(
                name: "Sprint");

            migrationBuilder.DropTable(
                name: "Projeto");
        }
    }
}
