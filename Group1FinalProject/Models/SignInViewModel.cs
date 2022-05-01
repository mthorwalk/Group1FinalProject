using System.ComponentModel.DataAnnotations;

namespace Group1FinalProject.Models
{
    public class SignInViewModel
    {
        public int? Id { get; set; }

        [Required]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Email isn't in the correct format")]
        public string? Email { get; set; }
        [Required]
        [StringLength(30,MinimumLength = 8, ErrorMessage = "Password should be at least 8 characters")]
        public string? Password { get; set; }
      
        public Boolean? Success { get; set; }
        public string? ErrorMessage { get; set; }

    }
}

