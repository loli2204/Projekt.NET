using Microsoft.EntityFrameworkCore;

namespace PhotographyApp.Models
{
    // Databaskontext som hanterar anslutningen till databasen och entiteterna (User, Package, Booking)
    public class DataContext : DbContext
    {
        // Konstruktor som tar alternativ för databaskonfiguration
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        // DbSet-egenskaper för varje entitet som ska representeras i databasen
        public DbSet<User> Users { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Booking> Bookings { get; set; }
    }
}
