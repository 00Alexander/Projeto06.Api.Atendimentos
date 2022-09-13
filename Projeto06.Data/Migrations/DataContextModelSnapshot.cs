﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Projeto06.Data.Contexts;

#nullable disable

namespace Projeto06.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Projeto06.Domain.Models.Atendimento", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClienteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("Data")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan?>("Hora")
                        .HasColumnType("time");

                    b.Property<string>("Observacoes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Valor")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("Atendimento");
                });

            modelBuilder.Entity("Projeto06.Domain.Models.AtendimentoServico", b =>
                {
                    b.Property<Guid>("AtendimentoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ServicoId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("AtendimentoId", "ServicoId");

                    b.HasIndex("ServicoId");

                    b.ToTable("AtendimentoServico");
                });

            modelBuilder.Entity("Projeto06.Domain.Models.Cliente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.HasIndex("Telefone")
                        .IsUnique()
                        .HasFilter("[Telefone] IS NOT NULL");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("Projeto06.Domain.Models.Servico", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal?>("Preco")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("Nome")
                        .IsUnique()
                        .HasFilter("[Nome] IS NOT NULL");

                    b.ToTable("Servicos");
                });

            modelBuilder.Entity("Projeto06.Domain.Models.Atendimento", b =>
                {
                    b.HasOne("Projeto06.Domain.Models.Cliente", "Cliente")
                        .WithMany("Atendimentos")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("Projeto06.Domain.Models.AtendimentoServico", b =>
                {
                    b.HasOne("Projeto06.Domain.Models.Atendimento", "Atendimento")
                        .WithMany("AtendimentosServicos")
                        .HasForeignKey("AtendimentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Projeto06.Domain.Models.Servico", "Servico")
                        .WithMany("AtendimentosServicos")
                        .HasForeignKey("ServicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Atendimento");

                    b.Navigation("Servico");
                });

            modelBuilder.Entity("Projeto06.Domain.Models.Atendimento", b =>
                {
                    b.Navigation("AtendimentosServicos");
                });

            modelBuilder.Entity("Projeto06.Domain.Models.Cliente", b =>
                {
                    b.Navigation("Atendimentos");
                });

            modelBuilder.Entity("Projeto06.Domain.Models.Servico", b =>
                {
                    b.Navigation("AtendimentosServicos");
                });
#pragma warning restore 612, 618
        }
    }
}
