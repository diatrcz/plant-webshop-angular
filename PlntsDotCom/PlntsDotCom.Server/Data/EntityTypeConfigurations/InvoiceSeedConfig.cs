using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PlntsDotCom.Server.Data.EntityTypeConfigurations;

public class InvoiceSeedConfig : IEntityTypeConfiguration<Invoice>
{
    public void Configure(EntityTypeBuilder<Invoice> builder)
    {
        builder.HasData(
            new Invoice { Id = 1, OrderId = 1, Amount = 10000, InvoiceDate = new DateTime(2023, 1, 15) }, 
            new Invoice { Id = 2, OrderId = 2, Amount = 15000, InvoiceDate = new DateTime(2023, 2, 20) }, 
            new Invoice { Id = 3, OrderId = 3, Amount = 20000, InvoiceDate = new DateTime(2023, 3, 25) }  
                                                                                                             
        );
    }
}
