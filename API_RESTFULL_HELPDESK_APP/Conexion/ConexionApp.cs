using API_RESTFULL_HELPDESK_APP.Controllers.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace API_RESTFULL_HELPDESK_APP.Controllers.Conexion
{
    public class ConexionApp : DbContext
    {
        public ConexionApp( DbContextOptions<ConexionApp> options):base(options)
        {
            
        }

        public DbSet<CTipoServicio> CTipoServicio { get; set; }
        public object Respuestas { get; set; }
        public DbSet<CModalidades> CModalidades { get; set; }
        public DbSet<TTickets> TTickets { get; set; }
        public DbSet<vw_TTickets> vw_TTickets { get; set; }
        public DbSet<Prioridades> CPrioridad { get; set; }
        public DbSet<CEmpresas> CEmpresas { get; set; }
        public DbSet<TUsuarios> TUsuarios { get; set; }
    }

    public class Conexion
    {
        static readonly string Server = "201.149.34.185,15002";

        static readonly string Db = "SoporteAppc";
        //static readonly string Db = "IPSNet";
        static readonly string User = "IPSNet";
        static readonly string Pass = "IPSNet2";
        protected SqlConnection conexion { get; set; }

        protected SqlConnection Conectar()
        {
            try
            {
                conexion = new SqlConnection("Data Source=" + Server + ";Initial Catalog=" + Db + ";User ID=" + User + ";Password=" + Pass + ";Integrated Security=False");
                //  conexion = new SqlConnection("Data Source = DESKTOP-CNPFA5C; Initial Catalog=IPSNet; Integrated Security = true");

                conexion.Open();
                return conexion;
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
                return null;
            }
        }
    }
}
