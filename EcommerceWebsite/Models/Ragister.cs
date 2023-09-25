using System.ComponentModel.DataAnnotations;


namespace EcommerceWebsite.Models
{
    public class Ragister
    {
        [Key]
        public int UId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string MobileNo { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }
        public int RoleId { get; set; }

    }
}
