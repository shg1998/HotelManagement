using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Data
{
    public class DatabaseContext : IdentityDbContext<ApiUser>
    {
        public DatabaseContext(DbContextOptions options) : base(options) { }

       
        public DbSet<Country> Countries { get; set; }
        public DbSet<Hotel> Hotels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Country>().HasData(
                new List<Country>
                {
                    new()
                    {
                        Id = 1,
                        Name = "Iran",
                        ShortName="I.R.I"
                    },
                    new()
                    {
                        Id = 2,
                        Name = "Jamaica",
                        ShortName = "JM"
                    }
                }
            );
            modelBuilder.Entity<Hotel>().HasData(
                new List<Hotel>
                {
                    new()
                    {
                        Id = 1,
                        Name = "Pasargad",
                        Address = "Shariati av,",
                        CountryId = 1,
                        Rating = 4.6
                    },
                    new()
                    {
                        Id = 2,
                        Name = "Sandals Resort and Spa",
                        Address = "Negril",
                        CountryId = 2,
                        Rating = 4.4
                    }
                }
            );
            //base.OnModelCreating(modelBuilder);
        }


    }
}
