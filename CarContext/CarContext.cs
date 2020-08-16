using car_webapi.db.models;
using Microsoft.EntityFrameworkCore;

namespace car_webapi.db.context
{
    public class CarContext : DbContext
    {
        public CarContext(DbContextOptions options) : base(options) { }
        public DbSet<Motor> Motor { get; set; }
        public DbSet<Lackierung> Lackierung { get; set; }
        public DbSet<Felgen> Felgen { get; set; }
        public DbSet<Auftrag> Auftrag { get; set; }
        public DbSet<Ausstattung> Ausstattung { get; set; }
        public DbSet<Exclusion> Exclusion { get; set; }
        public DbSet<Sonderausstattung> Sonderausstattung { get; set; }

    }
}