using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PlntsDotCom.Server.Data.EntityTypeConfigurations;

public class OrderSeedConfig : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasData(
            new Order
            {
                Id = 1,
                StatusId = 1,
                OrderDate = new DateTime(2023, 1, 10)
            },
            new Order
            {
                Id = 2,
                StatusId = 2,
                OrderDate = new DateTime(2023, 2, 15)
            },
            new Order
            {
                Id = 3,
                StatusId = 1,
                OrderDate = new DateTime(2023, 3, 20)
            }
        );
    }
}
