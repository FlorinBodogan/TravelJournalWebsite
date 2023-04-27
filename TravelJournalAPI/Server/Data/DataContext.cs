using Microsoft.EntityFrameworkCore;
using TravelJournalAPI.Server.Entities;

namespace TravelJournalAPI.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)  
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Holiday> Holidays { get; set; }
        public DbSet<Image> Images { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.Holidays)
                .WithOne(h => h.User)
                .HasForeignKey(h => h.UserId);

            modelBuilder.Entity<Holiday>()
                .HasMany(i => i.Images)
                .WithOne(h => h.Holiday)
                .HasForeignKey(h => h.HolidayId);
        }
    }
}
