using Microsoft.EntityFrameworkCore;

namespace Clinica_SePrice.Entidades
{
    public class ClinicaContext : DbContext
    {
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Turno> Turnos { get; set; }
        public DbSet<SalaEspera> SalaEspera { get; set; }
        public DbSet<EstudioMedico> EstudiosMedicos { get; set; }
        public DbSet<Especialidad> Especialidades { get; set; }
        public DbSet<EspecialidadEstudioMedico> EspecialidadesEstudiosMedicos { get; set; }
        public DbSet<Pago> Pagos { get; set; }
        public DbSet<Insumo> Insumos { get; set; }
        public DbSet<TransaccionInsumo> TransaccionesInsumos { get; set; }

        public ClinicaContext(DbContextOptions<ClinicaContext> options) : base(options)
        {
        }

        public ClinicaContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Server=127.0.0.1;Port=3306;Database=clinicaseprice;Uid=root;Pwd=Belgrano1132;";
            var serverVersion = new Version(8, 0, 34);
            optionsBuilder.UseMySql(connectionString, ServerVersion.Parse(serverVersion.ToString()));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Medico>().ToTable("Medicos");
            modelBuilder.Entity<Paciente>().ToTable("Pacientes");
            modelBuilder.Entity<Turno>().ToTable("Turnos");
            modelBuilder.Entity<SalaEspera>().ToTable("SalaEspera");
            modelBuilder.Entity<EstudioMedico>().ToTable("EstudiosMedicos");
            modelBuilder.Entity<Especialidad>().ToTable("Especialidades");
            modelBuilder.Entity<EspecialidadEstudioMedico>().ToTable("EspecialidadesEstudiosMedicos");
            modelBuilder.Entity<Pago>().ToTable("Pagos");
            modelBuilder.Entity<Insumo>().ToTable("Insumos");
            modelBuilder.Entity<TransaccionInsumo>().ToTable("TransaccionesInsumos");


        }
    }


     
    
}