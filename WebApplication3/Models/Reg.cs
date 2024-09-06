using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class Reg
    {
        [Required(ErrorMessage ="required field")]
        public string Name { get; set; }
        [Required(ErrorMessage = "required field")]
        public string Age { get; set; }
        [Required(ErrorMessage = "required field")]

        public string email { get; set; }
        [Required(ErrorMessage = "required field")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "required field")]
        public string Country { get; set; }
        [Required(ErrorMessage = "required field")]
        public string State { get; set; }
        [Required(ErrorMessage = "required field")]
        public string City { get; set; }
       

        [Required(ErrorMessage = "please enter password")]
     
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
    
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "password does match")]
        public string CPassword { get; set; }


    }  
}
