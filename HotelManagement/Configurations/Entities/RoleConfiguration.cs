using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelManagement.Configurations.Entities
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new List<IdentityRole>
                {
                    new()
                    {
                        Name = "User",
                        NormalizedName = "USER"
                    },
                    new()
                    {
                        Name = "Administrator",
                        NormalizedName = "ADMINISTRATOR"
                    }
                }
            );
        }
    }
}
