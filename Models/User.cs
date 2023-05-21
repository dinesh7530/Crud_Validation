using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_Validation.Models
{
    public class User
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public int RoleId { get; set; }

        [Display(Name="Username")]
        [MinLength(6, ErrorMessage = "Please enter a username 6 to 10 character")]
        [RegularExpression(@"^[a-zA-Z]+[0-9]*$", ErrorMessage = "Your username must be contain alphanumeric")]
        public string UserName { get; set; }

        [Display(Name ="Full Name")]
        [Required(ErrorMessage ="Please enter your Full Name")]
        [RegularExpression(@"^[a-zA-Z]+[ a-zA-Z-_]*$", ErrorMessage = "Please use letters only")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Please select your gender !")]
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "Please enter your Password !")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Please enter a password 6 to 10 character")]
        [MaxLength(10, ErrorMessage = "Entered password greater then 10 character")]
        [RegularExpression(@"^[a-zA-Z]+[0-9]*$", ErrorMessage = "Your password must be contain alphanumeric")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please enter your Confirm Password !")]
        [Display(Name="Confirm Password")]
        [Compare("Password",ErrorMessage ="Your confirm password is not matched with password !")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

    }

    public enum Role
    {
        Admin
    }

    public enum Gender
    {
        Male = 1,
        Female= 2,
    }
}
