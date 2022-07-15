using System.ComponentModel.DataAnnotations;

namespace HotelManagement.Models
{
    public class LoginDTO
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "Your Password is limited to 15 chars")]
        public string Password { get; set; }
    }

    public class UserDTO: LoginDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

       

    }
}
