using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DemoContext : DbContext
    {
        public string DbPath { get; private set; }

        public DbSet<Persona> Personas { get; set; }
        public DbSet<Telefono> Telefonos { get; set; }

        public DemoContext()
        {
            string folder = Environment.CurrentDirectory;
            DbPath = $"{folder}{Path.DirectorySeparatorChar}Demo.db";
        }

        public DemoContext(DbContextOptions<DemoContext> options) : base(options)
        {
            string folder = Environment.CurrentDirectory;
            DbPath = $"{folder}{Path.DirectorySeparatorChar}Demo.db";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            _ = optionsBuilder.UseSqlite($"Data Source={DbPath}");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
