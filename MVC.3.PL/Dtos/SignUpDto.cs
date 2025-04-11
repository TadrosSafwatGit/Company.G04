using System.ComponentModel.DataAnnotations;
using Microsoft.Build.Framework;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVC._3.PL.Dtos
{
    public class SignUpDto
    {

        [Required (ErrorMessage = "user Name is Required ")]
        public  string UserName { get; set; }

        [Required(ErrorMessage = "first Name is Required ")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is Required ")]
        public string LastName { get; set; }
      
        [EmailAddress]
        [Required(ErrorMessage = "Email is Required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password),ErrorMessage ="Confirm Password dose not match the Password !!")]
        public string ConfirmPassword { get; set; }

    
        public bool IsAgree { get; set; }




    }
}
