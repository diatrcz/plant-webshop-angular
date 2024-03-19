using System.ComponentModel.DataAnnotations;

namespace PlntsDotCom.Server.Data;
public class Order
{
    public int Id { get; set; }

    public int StatusId { get; set; }

    public User? User { get; set; }

    public virtual ICollection<OrderedItem> OrderItems { get; set; } = new List<OrderedItem>();
    public Invoice? Invoice { get; set; }

    [Required]
    public DateTime OrderDate { get; set; }

    public virtual Status? Status { get; set; }
}

