using Hotel.Repository.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Repository
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }

        #region DbSets
        public DbSet<GuestEntity> Guests { get; set; }
        public DbSet<RoomEntity> Rooms { get; set; }
        public DbSet<BookingEntity> Bookings { get; set; }
        public DbSet<NotificationEntity> Notifications { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GuestEntity>(entity => 
            { 
                entity.HasKey(g => g.Id);
            });    

            modelBuilder.Entity<GuestEntity>(entity =>
            {
                entity.HasIndex(g => g.Email).IsUnique();
            });

            modelBuilder.Entity<RoomEntity>(entity =>
            {
                entity.HasKey(r => r.Id);
            });

            modelBuilder.Entity<RoomEntity>(entity =>
            {
                entity.HasIndex(r => r.RoomNumber).IsUnique();
            });

            modelBuilder.Entity<BookingEntity>(entity =>
            {
                entity.HasKey(b => b.Id);
            });

            modelBuilder.Entity<BookingEntity>(entity =>
            {
                entity.HasIndex(b => b.BookingNumber).IsUnique();
            });

            modelBuilder.Entity<BookingEntity>()
              .HasOne(b => b.Guest)
              .WithMany(g => g.Bookings);

            modelBuilder.Entity<BookingEntity>()
              .HasOne(b => b.Room)
              .WithMany(r => r.Bookings);

            base.OnModelCreating(modelBuilder);
        }

    }
}
