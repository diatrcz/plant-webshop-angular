using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PlntsDotCom.Server.Data.EntityTypeConfigurations;

public class ProductSeedConfig : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasData(
            new Product
            {
                Id = 1,
                Name = "Rose Plant",
                Price = 1999,
                Stock = 50,
                Description = "Beautiful rose plant suitable for gardens or indoor decoration.",
                CategoryId = 4
            },
            new Product
            {
                Id = 2,
                Name = "Ceramic Flower Pot",
                Price = 1299,
                Stock = 100,
                Description = "Elegant ceramic flower pot, perfect for displaying your plants.",
                CategoryId = 2
            },
            new Product
            {
                Id = 3,
                Name = "Lavender Plant",
                Price = 1599,
                Stock = 30,
                Description = "Fragrant lavender plant, ideal for adding beauty and aroma to your garden.",
                CategoryId = 1
            },
            new Product
            {
                Id = 4,
                Name = "Terracotta Pot",
                Price = 9990,
                Stock = 80,
                Description = "Classic terracotta pot for planting various types of flowers and herbs.",
                CategoryId = 2 
            },
            new Product
            {
                Id = 5,
                Name = "Snake Plant",
                Price = 2499,
                Stock = 20,
                Description = "Low-maintenance snake plant, perfect for indoor environments.",
                CategoryId = 1 
            },
            new Product
            {
                Id = 6,
                Name = "Hanging Basket",
                Price = 1849,
                Stock = 40,
                Description = "Stylish hanging basket for displaying trailing plants.",
                CategoryId = 3 
            },
            new Product
            {
                Id = 7,
                Name = "Succulent Collection",
                Price = 29990,
                Stock = 15,
                Description = "Assorted succulent collection, perfect for adding variety to your garden.",
                CategoryId = 1 
            },
            new Product
            {
                Id = 8,
                Name = "Watering Can",
                Price = 8990,
                Stock = 60,
                Description = "Functional watering can for efficiently watering your plants.",
                CategoryId = 3 
            },
            new Product
            {
                Id = 9,
                Name = "Bonsai Tree",
                Price = 3499,
                Stock = 25,
                Description = "Artfully crafted bonsai tree, symbolizing peace and tranquility.",
                CategoryId = 1 
            },
            new Product
            {
                Id = 10,
                Name = "Garden Gloves",
                Price = 6990,
                Stock = 75,
                Description = "Durable garden gloves for protecting your hands while gardening.",
                CategoryId = 3 
            }
        );
    }
}
