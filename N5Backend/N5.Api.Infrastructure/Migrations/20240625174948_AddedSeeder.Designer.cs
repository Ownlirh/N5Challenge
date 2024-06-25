﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using N5.Api.Infrastructure.Context;

#nullable disable

namespace N5.Api.Infrastructure.Migrations
{
    [DbContext(typeof(N5Context))]
    [Migration("20240625174948_AddedSeeder")]
    partial class AddedSeeder
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("N5.Api.Domain.Entities.EmployerPermission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("PermissionId")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.HasIndex("PermissionId");

                    b.ToTable("EmployerPermissions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2024, 6, 25, 17, 49, 48, 20, DateTimeKind.Utc).AddTicks(4794),
                            Name = "Jhon",
                            PermissionId = 1,
                            Surname = "Doe"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2024, 6, 25, 17, 49, 48, 20, DateTimeKind.Utc).AddTicks(4802),
                            Name = "Jane",
                            PermissionId = 2,
                            Surname = "Doe"
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2024, 6, 25, 17, 49, 48, 20, DateTimeKind.Utc).AddTicks(4804),
                            Name = "Seven",
                            PermissionId = 3,
                            Surname = "Doe"
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(2024, 6, 25, 17, 49, 48, 20, DateTimeKind.Utc).AddTicks(4805),
                            Name = "Clop",
                            PermissionId = 4,
                            Surname = "Doe"
                        });
                });

            modelBuilder.Entity("N5.Api.Domain.Entities.PermissionType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.ToTable("PermissionTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "UI/UX"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Programmer"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Designer"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Team Lead"
                        });
                });

            modelBuilder.Entity("N5.Api.Domain.Entities.EmployerPermission", b =>
                {
                    b.HasOne("N5.Api.Domain.Entities.PermissionType", "PermissionTypeRel")
                        .WithMany("Employers")
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PermissionTypeRel");
                });

            modelBuilder.Entity("N5.Api.Domain.Entities.PermissionType", b =>
                {
                    b.Navigation("Employers");
                });
#pragma warning restore 612, 618
        }
    }
}
