﻿// <auto-generated />
using System;
using Empresa.Projeto.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Empresa.Projeto.Infra.Migrations
{
    [DbContext(typeof(AppContext))]
    [Migration("20220120201644_Add-rg")]
    partial class Addrg
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13");

            modelBuilder.Entity("Empresa.Projeto.Domain.Usuario", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<DateTime?>("AlteradoEm")
                        .HasColumnType("datetime2");

                    b.Property<string>("Apelido")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Apelido");

                    b.Property<DateTime?>("CriadoEm")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Email");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Nome");

                    b.Property<int>("Rg")
                        .HasColumnType("int");

                    b.Property<string>("Senha")
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)")
                        .HasColumnName("Senha");

                    b.Property<string>("Sobrenome")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Sobrenome");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Usuario");
                });
#pragma warning restore 612, 618
        }
    }
}
