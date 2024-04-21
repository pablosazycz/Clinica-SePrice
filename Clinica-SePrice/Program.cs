using Clinica_SePrice.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Diagnostics;

namespace Clinica_SePrice
{
    public static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {


            string connectionString = "Server=127.0.0.1;Port=3306;Database=clinicaseprice;Uid=root;Pwd=Belgrano1132;";
            var serverVersion = new Version(8, 0, 34);

            var optionsBuilder = new DbContextOptionsBuilder<ClinicaContext>();
            optionsBuilder.UseMySql(connectionString, ServerVersion.Parse(serverVersion.ToString()));

            var dbContext = new ClinicaContext(optionsBuilder.Options);
            dbContext.Database.EnsureCreated();

            // Inicializar la aplicación Windows Forms
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(dbContext));


        }
    }
}