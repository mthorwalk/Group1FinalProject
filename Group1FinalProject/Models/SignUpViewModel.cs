using System.ComponentModel.DataAnnotations;
namespace Group1FinalProject.Models
{
    public class SignUpViewModel
    {
        public int? Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Email isn't in the correct format")]
        public string Email { get; set; }

        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Phone isn't in the correct format")]
        [StringLength(15, MinimumLength = 10, ErrorMessage = "Phone number isnt in the correct length")]
        public string PhoneNumber { get; set; }
        [Required]
        public string Address { get; set; }

        public string? Address2 { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Zip { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 8, ErrorMessage = "Password should be at least 8 characters")]
        public string? Password { get; set; }
        public Boolean? Success { get; set; }
        public string? ErrorMessage { get; set; }


    }
}
