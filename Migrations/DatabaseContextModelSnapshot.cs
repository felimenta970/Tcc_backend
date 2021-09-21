﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tcc_backend.DataBaseConfig;

namespace Tcc_backend.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Tcc_backend.Entities.Anexo", b =>
                {
                    b.Property<int>("AnexoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoAnexo")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserStoryID")
                        .HasColumnType("int");

                    b.HasKey("AnexoID");

                    b.HasIndex("UserStoryID");

                    b.ToTable("Anexo");
                });

            modelBuilder.Entity("Tcc_backend.Entities.Commit", b =>
                {
                    b.Property<int>("CommitID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserStoryID")
                        .HasColumnType("int");

                    b.HasKey("CommitID");

                    b.HasIndex("UserStoryID");

                    b.ToTable("Commit");
                });

            modelBuilder.Entity("Tcc_backend.Entities.Membro", b =>
                {
                    b.Property<int>("MembroID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MembroID");

                    b.ToTable("Membro");
                });

            modelBuilder.Entity("Tcc_backend.Entities.Mudanca", b =>
                {
                    b.Property<int>("MudancaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ChangeReason")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataModificacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProjectManagerID")
                        .HasColumnType("int");

                    b.Property<int>("UserStoryID")
                        .HasColumnType("int");

                    b.HasKey("MudancaID");

                    b.HasIndex("ProjectManagerID");

                    b.HasIndex("UserStoryID");

                    b.ToTable("Mudanca");
                });

            modelBuilder.Entity("Tcc_backend.Entities.ProjectManager", b =>
                {
                    b.Property<int>("ProjectManagerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProjectManagerID");

                    b.ToTable("ProjectManager");
                });

            modelBuilder.Entity("Tcc_backend.Entities.Projeto", b =>
                {
                    b.Property<int>("ProjetoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("InitialDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2021, 9, 20, 20, 44, 12, 847, DateTimeKind.Local).AddTicks(6070));

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UrlGit")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProjetoID");

                    b.ToTable("Projeto");
                });

            modelBuilder.Entity("Tcc_backend.Entities.Sprint", b =>
                {
                    b.Property<int>("SprintID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProjetoID")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SprintID");

                    b.HasIndex("ProjetoID");

                    b.ToTable("Sprint");
                });

            modelBuilder.Entity("Tcc_backend.Entities.UserStory", b =>
                {
                    b.Property<int>("UserStoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("MembroID")
                        .HasColumnType("int");

                    b.Property<int>("ProjectManagerID")
                        .HasColumnType("int");

                    b.Property<int>("ProjetoID")
                        .HasColumnType("int");

                    b.Property<int>("SprintID")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("WhatDesc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WhoDesc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WhyDesc")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserStoryID");

                    b.HasIndex("MembroID");

                    b.HasIndex("ProjectManagerID");

                    b.HasIndex("ProjetoID");

                    b.HasIndex("SprintID");

                    b.ToTable("UserStory");
                });

            modelBuilder.Entity("Tcc_backend.Entities.UsuarioProjeto", b =>
                {
                    b.Property<int>("UsuarioProjetoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProjetoID")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioID")
                        .HasColumnType("int");

                    b.Property<bool>("isProjectManager")
                        .HasColumnType("bit");

                    b.HasKey("UsuarioProjetoID");

                    b.HasIndex("ProjetoID");

                    b.ToTable("UsuarioProjeto");
                });

            modelBuilder.Entity("Tcc_backend.Entities.Anexo", b =>
                {
                    b.HasOne("Tcc_backend.Entities.UserStory", "UserStory")
                        .WithMany("Anexos")
                        .HasForeignKey("UserStoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserStory");
                });

            modelBuilder.Entity("Tcc_backend.Entities.Commit", b =>
                {
                    b.HasOne("Tcc_backend.Entities.UserStory", "UserStory")
                        .WithMany("Commits")
                        .HasForeignKey("UserStoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserStory");
                });

            modelBuilder.Entity("Tcc_backend.Entities.Mudanca", b =>
                {
                    b.HasOne("Tcc_backend.Entities.ProjectManager", "ProjectManager")
                        .WithMany()
                        .HasForeignKey("ProjectManagerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tcc_backend.Entities.UserStory", "UserStory")
                        .WithMany()
                        .HasForeignKey("UserStoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProjectManager");

                    b.Navigation("UserStory");
                });

            modelBuilder.Entity("Tcc_backend.Entities.Sprint", b =>
                {
                    b.HasOne("Tcc_backend.Entities.Projeto", "Projeto")
                        .WithMany("Sprints")
                        .HasForeignKey("ProjetoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Projeto");
                });

            modelBuilder.Entity("Tcc_backend.Entities.UserStory", b =>
                {
                    b.HasOne("Tcc_backend.Entities.Membro", "Membro")
                        .WithMany()
                        .HasForeignKey("MembroID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tcc_backend.Entities.ProjectManager", "ProjectManager")
                        .WithMany()
                        .HasForeignKey("ProjectManagerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tcc_backend.Entities.Projeto", "Projeto")
                        .WithMany("UserStories")
                        .HasForeignKey("ProjetoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tcc_backend.Entities.Sprint", null)
                        .WithMany("UserStories")
                        .HasForeignKey("SprintID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Membro");

                    b.Navigation("ProjectManager");

                    b.Navigation("Projeto");
                });

            modelBuilder.Entity("Tcc_backend.Entities.UsuarioProjeto", b =>
                {
                    b.HasOne("Tcc_backend.Entities.Projeto", "Projeto")
                        .WithMany()
                        .HasForeignKey("ProjetoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Projeto");
                });

            modelBuilder.Entity("Tcc_backend.Entities.Projeto", b =>
                {
                    b.Navigation("Sprints");

                    b.Navigation("UserStories");
                });

            modelBuilder.Entity("Tcc_backend.Entities.Sprint", b =>
                {
                    b.Navigation("UserStories");
                });

            modelBuilder.Entity("Tcc_backend.Entities.UserStory", b =>
                {
                    b.Navigation("Anexos");

                    b.Navigation("Commits");
                });
#pragma warning restore 612, 618
        }
    }
}
