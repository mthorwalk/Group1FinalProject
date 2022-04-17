namespace Group1FinalProject.Models
{
    public class SignInViewModel
    {
        public int? Id { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public Boolean? Success { get; set; }
        public string? ErrorMessage { get; set; }

    }
}
