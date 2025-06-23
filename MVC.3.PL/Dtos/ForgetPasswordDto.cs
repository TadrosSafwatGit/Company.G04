using System.ComponentModel.DataAnnotations;

namespace MVC._3.PL.Dtos
{
    public class ForgetPasswordDto
    {
        [EmailAddress]
        [Required(ErrorMessage = "Email is Required")]
        public string Email { get; set; }


    }
}
