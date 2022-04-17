namespace Group1FinalProject.Models
{
    public class SignUpViewModel
    {
        public int? Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public string Address2 { get; set; }

        public string City { get; set; }

        public string State { get; set; }
        public string Zip { get; set; }

        public string Country { get; set; }

        public string? Password { get; set; }
        public Boolean? Success { get; set; }
        public string? ErrorMessage { get; set; }


    }
}
