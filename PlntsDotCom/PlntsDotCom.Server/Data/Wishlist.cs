using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PlntsDotCom.Server.Data
{
    public class Wishlist
    {
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }  

        [Required]
        public int ProductId { get; set; }  

        [ForeignKey("UserId")]
        public User User { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        public DateTime AddedDate { get; set; } = DateTime.UtcNow;
    }
}
