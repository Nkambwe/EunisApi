﻿// <auto-generated />
using System;
using Eunis.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Eunis.Migrations
{
    [DbContext(typeof(EunisDbContext))]
    partial class EunisDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Eunis.Data.Models.Credentials", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Actions")
                        .IsRequired()
                        .HasMaxLength(2147483647)
                        .HasColumnType("text");

                    b.Property<string>("ClientId")
                        .IsRequired()
                        .HasMaxLength(2147483647)
                        .HasColumnType("text");

                    b.Property<string>("Code")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(2147483647)
                        .HasColumnType("text");

                    b.Property<DateTime>("PostedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("SecretKey")
                        .IsRequired()
                        .HasMaxLength(2147483647)
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(2147483647)
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Credentials");
                });

            modelBuilder.Entity("Eunis.Data.Models.EunisTransaction", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<decimal>("Amount")
                        .HasPrecision(9, 2)
                        .HasColumnType("numeric(9,2)");

                    b.Property<string>("BeneficiaryAccount")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("BeneficiaryName")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("character varying(120)");

                    b.Property<string>("ClientId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("CredentialsId")
                        .HasColumnType("bigint");

                    b.Property<string>("Destination")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)");

                    b.Property<string>("MobileNumber")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("character varying(25)");

                    b.Property<string>("Network")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)");

                    b.Property<string>("Particulars")
                        .IsRequired()
                        .HasMaxLength(225)
                        .HasColumnType("character varying(225)");

                    b.Property<DateTime>("PostedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("RequestId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("RequestType")
                        .HasColumnType("text");

                    b.Property<string>("StatusCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)");

                    b.Property<string>("VendorMessage")
                        .IsRequired()
                        .HasMaxLength(225)
                        .HasColumnType("character varying(225)");

                    b.Property<string>("VendorReference")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.HasKey("Id");

                    b.HasIndex("CredentialsId");

                    b.ToTable("Transactions", (string)null);
                });

            modelBuilder.Entity("Eunis.Data.Models.Settings", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("ParamName")
                        .IsRequired()
                        .HasMaxLength(225)
                        .HasColumnType("character varying(225)");

                    b.Property<string>("ParamValue")
                        .HasColumnType("text");

                    b.Property<DateTime>("PostedOn")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Settings");
                });

            modelBuilder.Entity("Eunis.Data.Models.EunisTransaction", b =>
                {
                    b.HasOne("Eunis.Data.Models.Credentials", "Client")
                        .WithMany("Transactions")
                        .HasForeignKey("CredentialsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("Eunis.Data.Models.Credentials", b =>
                {
                    b.Navigation("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}
