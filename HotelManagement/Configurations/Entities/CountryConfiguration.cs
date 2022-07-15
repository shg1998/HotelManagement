using System.Collections.Generic;
using HotelManagement.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelManagement.Configurations.Entities
{
    public class CountryConfiguration:IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasData(
                new List<Country>
                {
                    new()
                    {
                        Id = 1,
                        Name = "Iran",
                        ShortName = "I.R.I"
                    },
                    new()
                    {
                        Id = 2,
                        Name = "Jamaica",
                        ShortName = "JM"
                    }
                }
            );
        }
    }
}
