using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace EcommerceWebsite.Models
{
    public class Product
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public int Price { get; set; }
        public string? Imageurl { get; set; }
        [Required]
        [Display(Name = "Category Name")]
        public int Cid { get; set; }
        [Required]
        [Display(Name = "Category Name")]
        public string Cname { get; set; }
        [NotMapped]
        public int Quantity { get; set; }
        [NotMapped]
        public int OrderId { get; set; }
        [NotMapped]
        public int UId { get; set; }
        [NotMapped]
        public int CartId { get; set; }
    }
}
