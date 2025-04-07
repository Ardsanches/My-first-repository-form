using System.ComponentModel.DataAnnotations;

/* The FormData model represents the structure of the data being submitted through the form.
It contains properties that map to the columns in the database table. */



namespace WebApplication2.Models
{
    public class FormData
    {
        public int Id { get; set; } // Id is the unique identifier for each entry in the FormData table.

        [Required]
        [StringLength(100)]
        public string? Name { get; set; } // Name is a required string with a maximum length of 100 characters.

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string? Email { get; set; } // Email is a required string that must be in a valid email format, with a maximum length of 100 characters.
    }
} 
