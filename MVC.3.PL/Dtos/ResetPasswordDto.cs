using System.ComponentModel.DataAnnotations;

namespace MVC._3.PL.Dtos
{
    public class ResetPasswordDto
    {


        [Required(ErrorMessage = "Password is Required")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        [DataType(DataType.Password)]
        [Compare(nameof(NewPassword), ErrorMessage = "Confirm Password dose not match the Password !!")]
        public string ConfirmPassword { get; set; }





    }
}
