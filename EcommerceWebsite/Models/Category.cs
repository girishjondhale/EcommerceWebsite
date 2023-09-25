using System.ComponentModel.DataAnnotations;

namespace EcommerceWebsite.Models
{
    public class Category
    {
        [Key]
        [Required]
        public int Cid { get; set; }
        [Required]
        public string Cname { get; set; }
    }
}
