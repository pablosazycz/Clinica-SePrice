﻿// <auto-generated />
using System;
using Clinica_SePrice.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Clinica_SePrice.Migrations
{
    [DbContext(typeof(ClinicaContext))]
    partial class ClinicaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("Clinica_SePrice.Entidades.Especialidad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Especialidades", (string)null);
                });

            modelBuilder.Entity("Clinica_SePrice.Entidades.EspecialidadEstudioMedico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EspecialidadId")
                        .HasColumnType("int");

                    b.Property<int>("EstudioMedicoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EspecialidadId");

                    b.HasIndex("EstudioMedicoId");

                    b.ToTable("EspecialidadesEstudiosMedicos", (string)null);
                });

            modelBuilder.Entity("Clinica_SePrice.Entidades.EstudioMedico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .HasColumnType("longtext");

                    b.Property<string>("Nombre")
                        .HasColumnType("longtext");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("Id");

                    b.ToTable("EstudiosMedicos", (string)null);
                });

            modelBuilder.Entity("Clinica_SePrice.Entidades.Insumo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasColumnType("longtext");

                    b.Property<int>("StockActual")
                        .HasColumnType("int");

                    b.Property<int>("StockMaximo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Insumos", (string)null);
                });

            modelBuilder.Entity("Clinica_SePrice.Entidades.Medico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellido")
                        .HasColumnType("longtext");

                    b.Property<string>("Especialidad")
                        .HasColumnType("longtext");

                    b.Property<string>("Nombre")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Medicos", (string)null);
                });

            modelBuilder.Entity("Clinica_SePrice.Entidades.Paciente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellido")
                        .HasColumnType("longtext");

                    b.Property<string>("Dni")
                        .HasColumnType("longtext");

                    b.Property<bool>("EnSalaEspera")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Nombre")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Pacientes", (string)null);
                });

            modelBuilder.Entity("Clinica_SePrice.Entidades.Pago", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("FechaPago")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("MetodoPago")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("NombreObraSocial")
                        .HasColumnType("longtext");

                    b.Property<string>("NumeroObraSocial")
                        .HasColumnType("longtext");

                    b.Property<int>("TurnoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TurnoId");

                    b.ToTable("Pagos", (string)null);
                });

            modelBuilder.Entity("Clinica_SePrice.Entidades.SalaEspera", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("HoraEntrada")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("HoraLlamado")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("TurnoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("SalaEspera", (string)null);
                });

            modelBuilder.Entity("Clinica_SePrice.Entidades.TransaccionInsumo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CantidadUtilizada")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("InsumoId")
                        .HasColumnType("int");

                    b.Property<int>("TurnoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("InsumoId");

                    b.HasIndex("TurnoId");

                    b.ToTable("TransaccionesInsumos", (string)null);
                });

            modelBuilder.Entity("Clinica_SePrice.Entidades.Turno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Duracion")
                        .HasColumnType("int");

                    b.Property<int?>("EstudioMedicoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("Hora")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Lugar")
                        .HasColumnType("longtext");

                    b.Property<string>("Materiales")
                        .HasColumnType("longtext");

                    b.Property<int?>("MedicoId")
                        .HasColumnType("int");

                    b.Property<string>("Observaciones")
                        .HasColumnType("longtext");

                    b.Property<int>("PacienteId")
                        .HasColumnType("int");

                    b.Property<int?>("SalaEsperaId")
                        .HasColumnType("int");

                    b.Property<bool>("Sobreturno")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Validado")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.HasIndex("EstudioMedicoId");

                    b.HasIndex("MedicoId");

                    b.HasIndex("PacienteId");

                    b.HasIndex("SalaEsperaId")
                        .IsUnique();

                    b.ToTable("Turnos", (string)null);
                });

            modelBuilder.Entity("Clinica_SePrice.Entidades.EspecialidadEstudioMedico", b =>
                {
                    b.HasOne("Clinica_SePrice.Entidades.Especialidad", "Especialidad")
                        .WithMany("EstudiosMedicos")
                        .HasForeignKey("EspecialidadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Clinica_SePrice.Entidades.EstudioMedico", "EstudioMedico")
                        .WithMany("Especialidades")
                        .HasForeignKey("EstudioMedicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Especialidad");

                    b.Navigation("EstudioMedico");
                });

            modelBuilder.Entity("Clinica_SePrice.Entidades.Pago", b =>
                {
                    b.HasOne("Clinica_SePrice.Entidades.Turno", "Turno")
                        .WithMany()
                        .HasForeignKey("TurnoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Turno");
                });

            modelBuilder.Entity("Clinica_SePrice.Entidades.TransaccionInsumo", b =>
                {
                    b.HasOne("Clinica_SePrice.Entidades.Insumo", "Insumo")
                        .WithMany()
                        .HasForeignKey("InsumoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Clinica_SePrice.Entidades.Turno", "Turno")
                        .WithMany("TransaccionesInsumos")
                        .HasForeignKey("TurnoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Insumo");

                    b.Navigation("Turno");
                });

            modelBuilder.Entity("Clinica_SePrice.Entidades.Turno", b =>
                {
                    b.HasOne("Clinica_SePrice.Entidades.EstudioMedico", "Estudio")
                        .WithMany("Turnos")
                        .HasForeignKey("EstudioMedicoId");

                    b.HasOne("Clinica_SePrice.Entidades.Medico", "Medico")
                        .WithMany("Turnos")
                        .HasForeignKey("MedicoId");

                    b.HasOne("Clinica_SePrice.Entidades.Paciente", "Paciente")
                        .WithMany("Turnos")
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Clinica_SePrice.Entidades.SalaEspera", "SalaEspera")
                        .WithOne("Turno")
                        .HasForeignKey("Clinica_SePrice.Entidades.Turno", "SalaEsperaId");

                    b.Navigation("Estudio");

                    b.Navigation("Medico");

                    b.Navigation("Paciente");

                    b.Navigation("SalaEspera");
                });

            modelBuilder.Entity("Clinica_SePrice.Entidades.Especialidad", b =>
                {
                    b.Navigation("EstudiosMedicos");
                });

            modelBuilder.Entity("Clinica_SePrice.Entidades.EstudioMedico", b =>
                {
                    b.Navigation("Especialidades");

                    b.Navigation("Turnos");
                });

            modelBuilder.Entity("Clinica_SePrice.Entidades.Medico", b =>
                {
                    b.Navigation("Turnos");
                });

            modelBuilder.Entity("Clinica_SePrice.Entidades.Paciente", b =>
                {
                    b.Navigation("Turnos");
                });

            modelBuilder.Entity("Clinica_SePrice.Entidades.SalaEspera", b =>
                {
                    b.Navigation("Turno");
                });

            modelBuilder.Entity("Clinica_SePrice.Entidades.Turno", b =>
                {
                    b.Navigation("TransaccionesInsumos");
                });
#pragma warning restore 612, 618
        }
    }
}
