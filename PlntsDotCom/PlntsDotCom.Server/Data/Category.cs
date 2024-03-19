using System.ComponentModel.DataAnnotations;

namespace PlntsDotCom.Server.Data;
public class Category
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    public int? ParentCategoryId { get; set; }

    public  ICollection<Category>? InverseParentCategory { get; set; } = new List<Category>();

    public  Category? ParentCategory { get; set; }

    public  ICollection<Product>? Products { get; set; } = new List<Product>();
}
