﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using api.Infra.Database;

namespace api.Migrations
{
    [DbContext(typeof(EntityContext))]
    partial class EntityContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("api.Dominio.Entidade.Agendamento.Agendamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<decimal>("CustosAdicionais")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("DataAgendamento")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataColetaPrevista")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataColetaRealizada")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataEntregaPrevista")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataEntregaRealizada")
                        .HasColumnType("datetime2");

                    b.Property<double>("HorasLocacao")
                        .HasColumnType("float");

                    b.Property<int?>("IdChecklist")
                        .HasColumnType("int");

                    b.Property<int>("IdPessoa")
                        .HasColumnType("int");

                    b.Property<int>("IdVeiculo")
                        .HasColumnType("int");

                    b.Property<bool>("RealizadaVistoria")
                        .HasColumnType("bit");

                    b.Property<decimal>("SubTotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ValorHora")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ValorTotal")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("IdChecklist")
                        .IsUnique()
                        .HasFilter("[IdChecklist] IS NOT NULL");

                    b.HasIndex("IdPessoa");

                    b.HasIndex("IdVeiculo");

                    b.ToTable("schedule");
                });

            modelBuilder.Entity("api.Dominio.Entidade.Agendamento.Checklist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<bool>("Amassados")
                        .HasColumnType("bit");

                    b.Property<bool>("Arranhoes")
                        .HasColumnType("bit");

                    b.Property<bool>("CarroLimpo")
                        .HasColumnType("bit");

                    b.Property<bool>("TanqueCheio")
                        .HasColumnType("bit");

                    b.Property<int>("TanqueLitroPendent")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("checklists");
                });

            modelBuilder.Entity("api.Dominio.Entidade.Usuario.Pessoa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("Aniversario")
                        .HasColumnType("datetime2");

                    b.Property<string>("Cep")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cidade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Complemento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Documento")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Logradouro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("Tipo")
                        .HasColumnType("int");

                    b.Property<string>("Uf")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("api.Dominio.Entidade.Veiculo.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("categories");
                });

            modelBuilder.Entity("api.Dominio.Entidade.Veiculo.Marca", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("brands");
                });

            modelBuilder.Entity("api.Dominio.Entidade.Veiculo.Modelo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("models");
                });

            modelBuilder.Entity("api.Dominio.Entidade.Veiculo.Veiculo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Ano")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Combustivel")
                        .HasColumnType("int");

                    b.Property<int>("IdCategoria")
                        .HasColumnType("int");

                    b.Property<int>("IdMarca")
                        .HasColumnType("int");

                    b.Property<int>("IdModelo")
                        .HasColumnType("int");

                    b.Property<int>("IdVeiculo")
                        .HasColumnType("int");

                    b.Property<string>("LimitePorMalas")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)");

                    b.Property<decimal>("ValorHora")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("veiculoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdCategoria");

                    b.HasIndex("IdMarca");

                    b.HasIndex("IdModelo");

                    b.HasIndex("veiculoId");

                    b.ToTable("cars");
                });

            modelBuilder.Entity("api.Dominio.Entidade.Agendamento.Agendamento", b =>
                {
                    b.HasOne("api.Dominio.Entidade.Agendamento.Checklist", "Checklist")
                        .WithOne("Agendamento")
                        .HasForeignKey("api.Dominio.Entidade.Agendamento.Agendamento", "IdChecklist");

                    b.HasOne("api.Dominio.Entidade.Usuario.Pessoa", "Pessoa")
                        .WithMany("Agendamentos")
                        .HasForeignKey("IdPessoa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Dominio.Entidade.Veiculo.Veiculo", "Veiculo")
                        .WithMany("Agendamentos")
                        .HasForeignKey("IdVeiculo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Checklist");

                    b.Navigation("Pessoa");

                    b.Navigation("Veiculo");
                });

            modelBuilder.Entity("api.Dominio.Entidade.Veiculo.Veiculo", b =>
                {
                    b.HasOne("api.Dominio.Entidade.Veiculo.Categoria", "Categoria")
                        .WithMany("Veiculos")
                        .HasForeignKey("IdCategoria")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Dominio.Entidade.Veiculo.Marca", "Marca")
                        .WithMany("Veiculos")
                        .HasForeignKey("IdMarca")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Dominio.Entidade.Veiculo.Modelo", "Modelo")
                        .WithMany("Veiculos")
                        .HasForeignKey("IdModelo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Dominio.Entidade.Veiculo.Veiculo", "veiculo")
                        .WithMany()
                        .HasForeignKey("veiculoId");

                    b.Navigation("Categoria");

                    b.Navigation("Marca");

                    b.Navigation("Modelo");

                    b.Navigation("veiculo");
                });

            modelBuilder.Entity("api.Dominio.Entidade.Agendamento.Checklist", b =>
                {
                    b.Navigation("Agendamento");
                });

            modelBuilder.Entity("api.Dominio.Entidade.Usuario.Pessoa", b =>
                {
                    b.Navigation("Agendamentos");
                });

            modelBuilder.Entity("api.Dominio.Entidade.Veiculo.Categoria", b =>
                {
                    b.Navigation("Veiculos");
                });

            modelBuilder.Entity("api.Dominio.Entidade.Veiculo.Marca", b =>
                {
                    b.Navigation("Veiculos");
                });

            modelBuilder.Entity("api.Dominio.Entidade.Veiculo.Modelo", b =>
                {
                    b.Navigation("Veiculos");
                });

            modelBuilder.Entity("api.Dominio.Entidade.Veiculo.Veiculo", b =>
                {
                    b.Navigation("Agendamentos");
                });
#pragma warning restore 612, 618
        }
    }
}
