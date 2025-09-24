using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace mvcl4.Models
{
    public class User 
    {
        public int UserId { get; set; }
        [DisplayName("User First Name")]
        [Required(ErrorMessage = "This Field Required , Please Enter your First Name ")]
        [MinLength(3, ErrorMessage = "First Name Min Length is 3")]
        [MaxLength(50, ErrorMessage = "First Name max length is 50")]
        public string FirstName { get; set; }
        //---------------------------------------
        [DisplayName("User Last Name")]
        [Required(ErrorMessage = "This Field Required , Please Enter your Last Name ")]
        [MinLength(3, ErrorMessage = "Last Name Min Length is 3")]
        [MaxLength(50, ErrorMessage = "Last Name max length is 50")]
        public string LastName { get; set; }
        //-------------------------------------
        [DisplayName("User Email")] //name for ui
        [DataType(DataType.EmailAddress)]// to auto handel the email syntax
        [EmailAddress(ErrorMessage = "Emai must be valid")]
        [StringLength(100, ErrorMessage = "Email must be between 4 and 100", MinimumLength = 4)]
        public string Email { get; set; }
        //-----------------------------------
        [DisplayName("User password")] //name for ui
        [DataType(DataType.Password)]// handel password like hide it
        [Required(ErrorMessage = "Password  is Required")]
        [MinLength(3, ErrorMessage = "Password Min Length is 3")]
        [MaxLength(30, ErrorMessage = "Password max length is 30")]

        public string Password { get; set; }
        //---------------------------------------
        [NotMapped]
        [DisplayName("Confirm Password")] //name for ui
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password  is Required")]
        [MinLength(3, ErrorMessage = "Password Min Length is 3")]
        [MaxLength(30, ErrorMessage = "Password max length is 30")]
        [Compare("Password", ErrorMessage = "Confirm Password Not Match The Password")]
        public string ConfirmPassword { get; set; }



    }
}
