using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class AdminContext:DbContext
    {
        public DbSet<Hottel> hottels { get; set; }
        public DbSet<Employee> employees { get; set; }
        public DbSet<Room> rooms { get; set; }
        public DbSet<Booking> bookings { get; set; }
        public DbSet<Guest> guests { get; set; }
        public DbSet<RoomType> roomTypes { get; set; }
        public DbSet<Payment> payments { get; set; }


        public AdminContext(DbContextOptions<AdminContext> options)
            :base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Hottel>()
                .HasMany(x => x.rooms)
                .WithOne()
                .HasForeignKey(x => x.HottelId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Guest>()
                .HasOne(x => x.Hottel)
                .WithMany(x => x.guests)
                .HasForeignKey(x => x.HottelId)
                .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<Guest>()
                .HasOne(x => x.Booking)
                .WithOne()
                .HasForeignKey<Guest>(x => x.BookingId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Guest>()
               .HasOne(x => x.Room)
               .WithOne()
               .HasForeignKey<Guest>(x => x.RoomId)
               .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<Hottel>().HasData(
                new Hottel()
                {
                    Id=1,
                    Name="shams",
                    Address="Damascus",
                    Email="asd@gmail.com",
                    Phone="+9639777"
                }
                ) ;

            modelBuilder.Entity<RoomType>().HasData
                (
                new RoomType()
                {
                    Id=1,
                    NumOfBands=77,
                    TypeName="Top Lefil"
                }
                );
        }
    }
}
