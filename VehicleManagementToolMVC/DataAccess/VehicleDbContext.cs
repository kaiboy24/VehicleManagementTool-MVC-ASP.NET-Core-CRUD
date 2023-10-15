using Microsoft.EntityFrameworkCore;
using VehicleManagementToolMVC.Models.Entities;

namespace VehicleManagementToolMVC.DataAccess
{
    public class VehicleDbContext : DbContext
    {
        public VehicleDbContext(DbContextOptions options) : base(options) 
        {
        }

        public DbSet<Vehicle> Vehicles { get; set; }
    }
}
