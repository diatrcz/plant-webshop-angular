using System.ComponentModel.DataAnnotations;

namespace PlntsDotCom.Server.Data;
public class OrderedItem
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public int ProductId { get; set; }

    public Order? Order { get; set; } 

    public Product? Product { get; set; }

    [Required]
    public int Quantity { get; set; } = 0;
}
