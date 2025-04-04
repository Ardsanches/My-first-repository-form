using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class FormData
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string? Name { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string? Email { get; set; }
    }
} 