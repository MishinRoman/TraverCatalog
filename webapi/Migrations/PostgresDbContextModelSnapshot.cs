﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using webapi.Data;

#nullable disable

namespace webapi.Migrations
{
    [DbContext(typeof(PostgresDbContext))]
    partial class PostgresDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("webapi.Data.Models.Comment", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("TextComment")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("TravelModelId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("TravelModelId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("webapi.Data.Models.Media", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("Exists")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDirectory")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset>("LastModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("FileName");

                    b.Property<string>("PhysicalPath")
                        .HasColumnType("text")
                        .HasColumnName("Path");

                    b.Property<Guid>("TravelId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("TravelModelId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("TravelModelId");

                    b.ToTable("Medias");
                });

            modelBuilder.Entity("webapi.Data.Models.TravelModel", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Traverls");
                });

            modelBuilder.Entity("webapi.Data.Models.User", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("HashPassword")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.Property<Guid?>("TravelModelId")
                        .HasColumnType("uuid");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("TravelModelId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("webapi.Data.Models.Comment", b =>
                {
                    b.HasOne("webapi.Data.Models.TravelModel", null)
                        .WithMany("Comments")
                        .HasForeignKey("TravelModelId");
                });

            modelBuilder.Entity("webapi.Data.Models.Media", b =>
                {
                    b.HasOne("webapi.Data.Models.TravelModel", null)
                        .WithMany("Media")
                        .HasForeignKey("TravelModelId");
                });

            modelBuilder.Entity("webapi.Data.Models.User", b =>
                {
                    b.HasOne("webapi.Data.Models.TravelModel", null)
                        .WithMany("Users")
                        .HasForeignKey("TravelModelId");
                });

            modelBuilder.Entity("webapi.Data.Models.TravelModel", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Media");

                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
