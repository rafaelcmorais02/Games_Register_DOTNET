﻿// <auto-generated />
using System;
using CadastroJogos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CadastroJogos.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20210628222333_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CadastroJogos.Entities.Jogo", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("preco")
                        .HasColumnType("float");

                    b.Property<string>("produtora")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("JogosTabela");
                });
#pragma warning restore 612, 618
        }
    }
}
