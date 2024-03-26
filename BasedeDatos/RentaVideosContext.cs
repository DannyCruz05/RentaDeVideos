using CapaDatos.Modelos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace CapaDatos.BasedeDatos
{
    public class RentaVideosContext : DbContext
    {
        
        public RentaVideosContext() : base("RentaVideos")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<ClientesModel> Clientes { get; set; }
        public DbSet<PeliculasModel> Peliculas { get; set; }
        public DbSet<RentaModel> Renta { get; set; }
    }
}
