using System.ComponentModel.DataAnnotations;

namespace PlntsDotCom.Server.Data;

public class Product
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = "abc"; 

    [Required]
    public int Price { get; set; }

    public int? Stock { get; set; }

    public string? Description { get; set; }

    [Required]
    public int CategoryId { get; set; }

    public Category? Category { get; set; }

    public ICollection<OrderedItem> OrderedItems { get; set; } = new List<OrderedItem>();

    public string? ImageUrl { get; set; }
}
