using System.ComponentModel.DataAnnotations;

namespace PlntsDotCom.Server.Data;
public class Invoice
{
    public int Id { get; set; }

    public int? OrderId { get; set; }

    [Required]
    public int Amount { get; set; }

    [Required]
    public DateTime InvoiceDate { get; set; }
}
