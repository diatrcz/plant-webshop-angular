using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PlntsDotCom.Server.Data.EntityTypeConfigurations;

public class StatusSeedConfig : IEntityTypeConfiguration<Status>
{
    public void Configure(EntityTypeBuilder<Status> builder)
    {
        builder.HasData(
            new Status
            {
                StatusId = 1,
                Name = "Pending"
            },
            new Status
            {
                StatusId = 2,
                Name = "Processing"
            },
            new Status
            {
                StatusId = 3,
                Name = "Shipped"
            },
            new Status
            {
                StatusId = 4,
                Name = "Delivered"
            },
            new Status
            {
                StatusId = 5,
                Name = "Cancelled"
            }
        );
    }
}
