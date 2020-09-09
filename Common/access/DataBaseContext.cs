using Common.model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.access
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext() : base("AutoSkola")
        {
        }

        public DbSet<AutoSkola> AutoSkolaBaza { get; set; }
        public DbSet<Dozvola> Dozvole { get; set; }
        public DbSet<Instruktor> Instruktori { get; set; }
        public DbSet<Korisnik> Korisnici { get; set; }
    }
}
