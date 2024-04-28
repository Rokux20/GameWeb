using GameWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace GameWeb.Context
{
    public class FarmDbContext : DbContext
    {
        public FarmDbContext(DbContextOptions<FarmDbContext> options) : base(options)
        {
        }

        public DbSet<Farms> Farms { get; set; }
        public DbSet<Devices> Devices { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<Crops> Crops { get; set; }
        public DbSet<DevicesTypeEnergy> DevicesTypeEnergy { get; set; }
        public DbSet<TypeEnergy> TypeEnergy { get; set; }
    }
}
