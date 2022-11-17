using Capa_datos.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capa_datos
{
    public class GestionfarmaciaDbContext : DbContext
    {
        public DbSet<farmaceutico> Farmaceuticos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder option)
        {
            if (!option.IsConfigured)
            {
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json");
                var config = builder.Build();
                option.UseSqlServer(config["ConnectionStrings:miConexion"]);
            }
        }

    }
}
