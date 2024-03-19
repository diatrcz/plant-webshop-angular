using System.ComponentModel.DataAnnotations;

namespace PlntsDotCom.Server.Data
{
    public class Status
    {
        public int StatusId { get; set; }

        [Required]
        public string Name { get; set; } = "abc";

        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
