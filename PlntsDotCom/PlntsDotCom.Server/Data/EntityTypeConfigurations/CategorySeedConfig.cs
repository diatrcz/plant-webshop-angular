using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PlntsDotCom.Server.Data.EntityTypeConfigurations;

public class CategorySeedConfig : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        
        builder.HasData(
            new Category { Id = 1, Name = "Plants" },
            new Category { Id = 2, Name = "Pots" },
            new Category { Id = 3, Name = "Accessories" }
        );

      
        builder.HasData(
            new Category { Id = 4, Name = "Flowering Plants", ParentCategoryId = 1 },
            new Category { Id = 5, Name = "Succulents", ParentCategoryId = 1 },
            new Category { Id = 6, Name = "Ceramic Pots", ParentCategoryId = 2 },
            new Category { Id = 7, Name = "Terracotta Pots", ParentCategoryId = 2 },
            new Category { Id = 8, Name = "Fertilizers", ParentCategoryId = 3 },
            new Category { Id = 9, Name = "Tools", ParentCategoryId = 3 }
        );
    }
}
