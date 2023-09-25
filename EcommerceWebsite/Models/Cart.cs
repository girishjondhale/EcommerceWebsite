using System.ComponentModel.DataAnnotations;

namespace EcommerceWebsite.Models
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }

        public int Id { get; set; }
        [Required]
        public int Uid { get; set; }

        public int Quantity { get; set; }

    }
}
