using HotelManagement.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace HotelManagement.Configurations.Entities
{
    public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.HasData(
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
                });
        }
    }
}
