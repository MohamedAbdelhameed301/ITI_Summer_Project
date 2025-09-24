using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvcl4.Models
{
    public class Student
    {
        
        public int Id { get; set; }
        //----------------------------------------------------
        [DisplayName("Student Name")] //name for ui
        //the new dataannotation require migration to avoid the conflict with DB constrans
       [Required(ErrorMessage = "Please Enter your Name ")]// will override the error message
        [MinLength(3, ErrorMessage = "Name Min Length is 3")]
        [MaxLength(50, ErrorMessage = "Name max length is 50")]

        public string Name { get; set; }
        //----------------------------------------------
        [DisplayName("Student Age")] //name for ui
        [Range(20, 50, ErrorMessage = "Age must be between 20 and 40")]
        public int Age { get; set; }

        //------------------------------------------

        [DisplayName("Student Address")] //name for ui
        [StringLength(50, ErrorMessage = "Adress must be between 4 and 50", MinimumLength = 4)]
        public string Address { get; set; }

        //------------------------------------------

        [DisplayName("Student Email")] //name for ui
        [DataType(DataType.EmailAddress)]// to auto handel the email syntax
        [EmailAddress(ErrorMessage = "Emai must be valid")]
        [StringLength(100, ErrorMessage = "Email must be between 4 and 100", MinimumLength = 4)]
        public string Email { get; set; }

        //-------------------------------------------

        [DisplayName("Student password")] //name for ui
        [DataType(DataType.Password)]// handel password like hide it
        [Required(ErrorMessage = "Password  is Required")]
        [MinLength(3, ErrorMessage = "Password Min Length is 3")]
        [MaxLength(30, ErrorMessage = "Password max length is 30")]
        public string Password { get; set; }
        
        //-------------------------------------------

        [NotMapped]
        [DisplayName("Confirm Password")] //name for ui
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password  is Required")]
        [MinLength(3, ErrorMessage = "Password Min Length is 3")]
        [MaxLength(30, ErrorMessage = "Password max length is 30")]
        [Compare("Password", ErrorMessage = "Confirm Password not match password")]// compare with password field must be mathed
        public string ConfirmPassword { get; set; }

        //--------------------------------------------

        [ForeignKey("Department")]
        [DisplayName(" Department ID")] //name for ui

        public virtual int DeptId { get; set; } // FK

        //-------------------------------------------
        public virtual Department Department { get; set; }// ref

    }
}
