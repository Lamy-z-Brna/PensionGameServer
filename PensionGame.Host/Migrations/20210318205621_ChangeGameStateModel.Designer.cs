﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PensionGame.DataAccess;

namespace PensionGame.Host.Migrations
{
    [DbContext(typeof(PensionGameDbContext))]
    [Migration("20210318205621_ChangeGameStateModel")]
    partial class ChangeGameStateModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PensionGame.DataAccess.Data_Objects.ClientData.ClientData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GameStateId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GameStateId")
                        .IsUnique();

                    b.ToTable("ClientData");
                });

            modelBuilder.Entity("PensionGame.DataAccess.Data_Objects.GameData.GameState", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsFinished")
                        .HasColumnType("bit");

                    b.Property<int>("SessionId")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SessionId");

                    b.ToTable("GameStates");
                });

            modelBuilder.Entity("PensionGame.DataAccess.Data_Objects.Session.Session", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateStarted")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("PensionGame.DataAccess.Data_Objects.ClientData.ClientData", b =>
                {
                    b.HasOne("PensionGame.DataAccess.Data_Objects.GameData.GameState", "GameState")
                        .WithOne("ClientData")
                        .HasForeignKey("PensionGame.DataAccess.Data_Objects.ClientData.ClientData", "GameStateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GameState");
                });

            modelBuilder.Entity("PensionGame.DataAccess.Data_Objects.GameData.GameState", b =>
                {
                    b.HasOne("PensionGame.DataAccess.Data_Objects.Session.Session", "Session")
                        .WithMany()
                        .HasForeignKey("SessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Session");
                });

            modelBuilder.Entity("PensionGame.DataAccess.Data_Objects.GameData.GameState", b =>
                {
                    b.Navigation("ClientData");
                });
#pragma warning restore 612, 618
        }
    }
}
