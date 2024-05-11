using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace PlntsDotCom.Server.Data;
public class User: IdentityUser
{
    //public int? Id { get; set; }

    //[Required]
    //public string Username { get; set; } = "abc";

    //[Required]
    //public string Email { get; set; } = "abc";

    //[Required]
    //public string Password { get; set; } = "abc";

    [Required]
    public UserType Type { get; set; }

    public string? Address { get; set; }

    public ICollection<Order>? Orders { get; set; } = new List<Order>();

    public ICollection<Product>? WishlistItems { get; set; } = new List<Product>();
}


