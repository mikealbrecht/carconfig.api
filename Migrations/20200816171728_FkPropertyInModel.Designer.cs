﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using car_webapi.db.context;

namespace car_webapi.Migrations
{
    [DbContext(typeof(CarContext))]
    [Migration("20200816171728_FkPropertyInModel")]
    partial class FkPropertyInModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("car_webapi.db.models.Auftrag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("FelgenId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Guid")
                        .IsRequired()
                        .HasColumnType("varchar(36)")
                        .HasMaxLength(36);

                    b.Property<int?>("LackierungId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("MotorId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("FelgenId");

                    b.HasIndex("LackierungId");

                    b.HasIndex("MotorId");

                    b.ToTable("Auftrag");
                });

            modelBuilder.Entity("car_webapi.db.models.Ausstattung", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AuftragId")
                        .HasColumnType("int");

                    b.Property<int>("SonderausstattungId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AuftragId");

                    b.HasIndex("SonderausstattungId");

                    b.ToTable("Ausstattung");
                });

            modelBuilder.Entity("car_webapi.db.models.Exclusion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cannot")
                        .HasColumnType("int");

                    b.Property<int>("SonderausstattungId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SonderausstattungId");

                    b.ToTable("Exclusion");
                });

            modelBuilder.Entity("car_webapi.db.models.Felgen", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Felgen");
                });

            modelBuilder.Entity("car_webapi.db.models.Lackierung", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Lackierung");
                });

            modelBuilder.Entity("car_webapi.db.models.Motor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Motor");
                });

            modelBuilder.Entity("car_webapi.db.models.Sonderausstattung", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Sonderausstattung");
                });

            modelBuilder.Entity("car_webapi.db.models.Auftrag", b =>
                {
                    b.HasOne("car_webapi.db.models.Felgen", "Felgen")
                        .WithMany()
                        .HasForeignKey("FelgenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("car_webapi.db.models.Lackierung", "Lackierung")
                        .WithMany()
                        .HasForeignKey("LackierungId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("car_webapi.db.models.Motor", "Motor")
                        .WithMany()
                        .HasForeignKey("MotorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("car_webapi.db.models.Ausstattung", b =>
                {
                    b.HasOne("car_webapi.db.models.Auftrag", "Auftrag")
                        .WithMany()
                        .HasForeignKey("AuftragId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("car_webapi.db.models.Sonderausstattung", "Sonderausstattung")
                        .WithMany()
                        .HasForeignKey("SonderausstattungId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("car_webapi.db.models.Exclusion", b =>
                {
                    b.HasOne("car_webapi.db.models.Sonderausstattung", "Sonderausstattung")
                        .WithMany()
                        .HasForeignKey("SonderausstattungId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
