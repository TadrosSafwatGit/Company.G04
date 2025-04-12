using System.ComponentModel.DataAnnotations;

namespace MVC._3.PL.Dtos
{
    public class SignInDto
    {

        [EmailAddress]
        [Required(ErrorMessage = "Email is Required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }

    }
}
