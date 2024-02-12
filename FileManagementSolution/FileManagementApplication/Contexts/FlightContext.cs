using FileManagementApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace FileManagementApplication.Contexts
{
    public class FlightContext:DbContext
    {
        public FlightContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Flight>Flights { get; set; }
    }
}
