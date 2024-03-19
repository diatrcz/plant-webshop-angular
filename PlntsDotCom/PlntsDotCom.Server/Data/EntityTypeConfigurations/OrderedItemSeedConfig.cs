using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PlntsDotCom.Server.Data.EntityTypeConfigurations;

public class OrderedItemSeedConfig : IEntityTypeConfiguration<OrderedItem>
{
    public void Configure(EntityTypeBuilder<OrderedItem> builder)
    {
        builder.HasData(
            new OrderedItem
            {
                Id = 1,
                OrderId = 1,
                ProductId = 1,
                Quantity = 2
            },
            new OrderedItem
            {
                Id = 2,
                OrderId = 1,
                ProductId = 2,
                Quantity = 1
            },
            new OrderedItem
            {
                Id = 3,
                OrderId = 2,
                ProductId = 3,
                Quantity = 3
            },
            new OrderedItem
            {
                Id = 4,
                OrderId = 2,
                ProductId = 1,
                Quantity = 4
            },
            new OrderedItem
            {
                Id = 5,
                OrderId = 3,
                ProductId = 2,
                Quantity = 2
            }
        );
    }
}
