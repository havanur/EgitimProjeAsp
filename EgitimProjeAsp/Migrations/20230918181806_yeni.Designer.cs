﻿// <auto-generated />
using EgitimProjeAsp.Utility;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EgitimProjeAsp.Migrations
{
    [DbContext(typeof(UygulamaDBContext))]
    [Migration("20230918181806_yeni")]
    partial class yeni
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EgitimProjeAsp.Models.Kitap", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Fiyat")
                        .HasColumnType("float");

                    b.Property<string>("KitapAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KitapTuruId")
                        .HasColumnType("int");

                    b.Property<string>("ResimURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tanim")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Yazar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("KitapTuruId");

                    b.ToTable("Kitaplar");
                });

            modelBuilder.Entity("EgitimProjeAsp.Models.KitapTuru", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("id");

                    b.ToTable("KitapTuruleri");
                });

            modelBuilder.Entity("EgitimProjeAsp.Models.Kitap", b =>
                {
                    b.HasOne("EgitimProjeAsp.Models.KitapTuru", "KitapTuru")
                        .WithMany()
                        .HasForeignKey("KitapTuruId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("KitapTuru");
                });
#pragma warning restore 612, 618
        }
    }
}