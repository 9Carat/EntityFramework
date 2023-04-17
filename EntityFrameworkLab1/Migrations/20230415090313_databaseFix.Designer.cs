﻿// <auto-generated />
using System;
using EntityFrameworkLab1.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EntityFrameworkLab1.Migrations
{
    [DbContext(typeof(VacationDbContext))]
    [Migration("20230415090313_databaseFix")]
    partial class databaseFix
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EntityFrameworkLab1.Models.Employee", b =>
                {
                    b.Property<int>("EmpId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmpId"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("EmpId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("EntityFrameworkLab1.Models.Vacation", b =>
                {
                    b.Property<int>("VacationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VacationId"));

                    b.Property<DateTime>("ApplyDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("FK_EmpId")
                        .HasColumnType("int");

                    b.Property<DateTime>("VacationEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("VacationStart")
                        .HasColumnType("datetime2");

                    b.Property<string>("VacationType")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("VacationId");

                    b.HasIndex("FK_EmpId")
                        .IsUnique();

                    b.ToTable("Vacations");
                });

            modelBuilder.Entity("EntityFrameworkLab1.Models.Vacation", b =>
                {
                    b.HasOne("EntityFrameworkLab1.Models.Employee", "Employees")
                        .WithOne("Vacations")
                        .HasForeignKey("EntityFrameworkLab1.Models.Vacation", "FK_EmpId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employees");
                });

            modelBuilder.Entity("EntityFrameworkLab1.Models.Employee", b =>
                {
                    b.Navigation("Vacations");
                });
#pragma warning restore 612, 618
        }
    }
}
