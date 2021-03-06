using System.ComponentModel.DataAnnotations;

namespace DotNetPOC.Models
{
    public class User
    {
        [Required]        
        public int UserId { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]        
        public string Login { get; set; }
        [Required]
        [StringLength(100)]
        public string Password { get; set; }
        [Required]
        [StringLength(100)]
        public string Email { get; set; }
    }
}