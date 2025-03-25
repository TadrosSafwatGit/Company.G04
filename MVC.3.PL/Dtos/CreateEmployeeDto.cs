using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVC._3.PL.Dtos
{
    public class CreateEmployeeDto
    {
        [Required(ErrorMessage = "Name is  Required")]
        public string Name { get; set; }

        [Range(22,60)]
        public int? Age { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [RegularExpression(@"^\d{0,5}\s?[A-Za-z\s]+,\s?[A-Za-z\s]+,\s?[A-Za-z\s]+(\s?\d{5})?$",
    ErrorMessage = "Invalid address format. Example: '15 Tahrir St, Cairo, Egypt'")]
        public string Address { get; set; }


        [RegularExpression(@"^(\+20|0)?1[0-25]\d{8}$",
              ErrorMessage = "Invalid Egyptian phone number. Example: '+201234567890' or '01234567890'")]
        public string Phone { get; set; }

        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; } // soft or hard delete

        [DisplayName("hiring date")]
        public DateTime HiringDate { get; set; }

        [DisplayName("Date of Creation")]
        public DateTime CreateAt { get; set; }



    }
}
