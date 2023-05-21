using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_Validation.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Please enter your full name")]
        [RegularExpression(@"^[a-zA-Z]+[ a-zA-Z-_]*$", ErrorMessage = "Please use letters only")]
        public string Name { get; set; }


        [Required(ErrorMessage ="Please enter your age")]
        public int Age { get; set; }


        [Required(ErrorMessage = "Please check any option")]
        public string Gender { get; set; }


        [Required(ErrorMessage ="Please select any option")]
        public Qualification Qualification { get; set; }


        [Required(ErrorMessage ="Please enter your email")]
        [RegularExpression(@"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$", ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }


        [DataType(DataType.Password)]
        [Required(ErrorMessage ="Please enter your password")]
        [MinLength(6,ErrorMessage ="Entered password is less then 6 character")]
        [MaxLength(10,ErrorMessage = "Entered password greater then 10 character")]
        [RegularExpression(@"^[a-zA-Z]+[0-9]*$", ErrorMessage = "Your password must be contain alphanumeric")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Please enter your confirm password")]
        [Compare("Password",ErrorMessage = "Confirm password doesn't match")]

        public string ConfirmPassword { get; set; }

        public string IsActive { get; set; }
    }

    public enum Qualification
    {
        BCA=1,
        MCA=2,
        BTECH=3,
        MTECH=4,
        IIT=5
    }
}
