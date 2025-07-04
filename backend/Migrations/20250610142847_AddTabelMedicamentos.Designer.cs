﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using backend.Data;

#nullable disable

namespace backend.Migrations
{
    [DbContext(typeof(ClinicaContext))]
    [Migration("20250610142847_AddTabelMedicamentos")]
    partial class AddTabelMedicamentos
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("backend.Models.Consulta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataHora")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Observacao")
                        .HasColumnType("longtext");

                    b.Property<int>("PacienteId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("Id");

                    b.HasIndex("PacienteId");

                    b.ToTable("Consultas");
                });

            modelBuilder.Entity("backend.Models.Medicamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Medicamentos");
                });

            modelBuilder.Entity("backend.Models.Paciente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ContatoEmergencia")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("DataNascimento")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Diario")
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("Endereco")
                        .HasColumnType("longtext");

                    b.Property<bool>("MoraSozinho")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PlanoSaude")
                        .HasColumnType("longtext");

                    b.Property<int?>("PsiquiatraId")
                        .HasColumnType("int");

                    b.Property<int?>("ResponsavelLegalId")
                        .HasColumnType("int");

                    b.Property<string>("Telefone")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("PsiquiatraId");

                    b.HasIndex("ResponsavelLegalId");

                    b.ToTable("Pacientes");
                });

            modelBuilder.Entity("backend.Models.PacienteMedicamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DataFim")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Dosagem")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FormaFarmaceutica")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FrequenciaUso")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("MedicamentoId")
                        .HasColumnType("int");

                    b.Property<string>("Observacoes")
                        .HasColumnType("longtext");

                    b.Property<int>("PacienteId")
                        .HasColumnType("int");

                    b.Property<string>("Prescritor")
                        .HasColumnType("longtext");

                    b.Property<bool>("UsoContinuo")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("ViaAdministracao")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("MedicamentoId");

                    b.HasIndex("PacienteId");

                    b.ToTable("PacienteMedicamentos");
                });

            modelBuilder.Entity("backend.Models.Psiquiatra", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CRM")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Especialidade")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Psiquiatras");
                });

            modelBuilder.Entity("backend.Models.ResponsavelLegal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Parentesco")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("ResponsaveisLegais");
                });

            modelBuilder.Entity("backend.Models.Consulta", b =>
                {
                    b.HasOne("backend.Models.Paciente", "Paciente")
                        .WithMany("Consultas")
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Paciente");
                });

            modelBuilder.Entity("backend.Models.Paciente", b =>
                {
                    b.HasOne("backend.Models.Psiquiatra", "DadosPsiquiatra")
                        .WithMany("Pacientes")
                        .HasForeignKey("PsiquiatraId");

                    b.HasOne("backend.Models.ResponsavelLegal", "ResponsavelLegal")
                        .WithMany("Pacientes")
                        .HasForeignKey("ResponsavelLegalId");

                    b.Navigation("DadosPsiquiatra");

                    b.Navigation("ResponsavelLegal");
                });

            modelBuilder.Entity("backend.Models.PacienteMedicamento", b =>
                {
                    b.HasOne("backend.Models.Medicamento", "Medicamento")
                        .WithMany("PacientesMedicamentos")
                        .HasForeignKey("MedicamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("backend.Models.Paciente", "Paciente")
                        .WithMany("MedicamentosUsados")
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Medicamento");

                    b.Navigation("Paciente");
                });

            modelBuilder.Entity("backend.Models.Medicamento", b =>
                {
                    b.Navigation("PacientesMedicamentos");
                });

            modelBuilder.Entity("backend.Models.Paciente", b =>
                {
                    b.Navigation("Consultas");

                    b.Navigation("MedicamentosUsados");
                });

            modelBuilder.Entity("backend.Models.Psiquiatra", b =>
                {
                    b.Navigation("Pacientes");
                });

            modelBuilder.Entity("backend.Models.ResponsavelLegal", b =>
                {
                    b.Navigation("Pacientes");
                });
#pragma warning restore 612, 618
        }
    }
}
