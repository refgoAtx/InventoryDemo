using System.ComponentModel.DataAnnotations;

namespace IdentityProject.Model
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? firstname { get; set; }
        [Required]
        public string? lastname { get; set; }
        [Required]
        [EmailAddress]
        public string? email { get; set; }
        [Required]
        public string? Address { get; set; }
        [Required]
        [Phone]
        public string? Phone { get; set; }
        [Required]
        public string? Organization { get; set; }

        public DateTime Createdat { get; set; }
        public string? Createdby { get; set; }
        public DateTime Updatedat { get; set; }
        public string? Updatedby { get; set; }


    }
}
