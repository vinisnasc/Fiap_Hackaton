﻿// <auto-generated />
using System;
using Fiap_Hackaton.Health_Med.Data.Contexto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Fiap_Hackaton.Health_Med.Data.Migrations
{
    [DbContext(typeof(AppDbContexto))]
    [Migration("20250209000736_NomeDaMigracao")]
    partial class NomeDaMigracao
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Fiap_Hackaton.Health_Med.Domain.Entities.Agendamento", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool?>("Aprovado")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Horario")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("IdMedico")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdPaciente")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Agendamentos");
                });

            modelBuilder.Entity("Fiap_Hackaton.Health_Med.Domain.Entities.AspNetUsers", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Especializacao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Fiap_Hackaton.Health_Med.Domain.Entities.Disponibilidade", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("DiaSemana")
                        .HasColumnType("int");

                    b.Property<TimeOnly>("HorarioFinal")
                        .HasColumnType("time");

                    b.Property<TimeOnly>("HorarioInicial")
                        .HasColumnType("time");

                    b.Property<Guid>("IdMedico")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("ValorConsulta")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Disponibilidades", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
