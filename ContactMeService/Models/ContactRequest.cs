using System.ComponentModel.DataAnnotations;

namespace ContactMeService.Models
{
    public class ContactRequest
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"^(\+\d{1,2}\s)?\(?\d{3}\)?[\s.-]?\d{3}[\s.-]?\d{4}$", ErrorMessage = "Invalid phone number.")]
        public string PhoneNumber {  get; set; }

        [Required]
        [MaxLength(255, ErrorMessage = "Too long")]
        public string Message { get; set; }
    }
}
