﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RoleTracker.Data;

#nullable disable

namespace RoleTracker.Migrations
{
    [DbContext(typeof(RoleTrackerContext))]
    [Migration("20240215185223_GameSubEntity")]
    partial class GameSubEntity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.26")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("RoleTracker.Models.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Player")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Race")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("Character");
                });

            modelBuilder.Entity("RoleTracker.Models.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("HoursPlayed")
                        .HasColumnType("int");

                    b.Property<string>("MasterName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Game");
                });

            modelBuilder.Entity("RoleTracker.Models.Character", b =>
                {
                    b.HasOne("RoleTracker.Models.Game", "Game")
                        .WithMany()
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");
                });
#pragma warning restore 612, 618
        }
    }
}
