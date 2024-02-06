using System.ComponentModel.DataAnnotations;

namespace CompanyErp.Models
{
    public class LoginModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
    public class RegistrationModel : LoginModel
    {
    }

    public class ProfileDTO
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? MobileNo { get; set; }
        public string? Address { get; set; }
        public string? PinCode { get; set; }
        public string? About { get; set; }
    }

    public class ProfilePicDTO
    {
        public IFormFile ProfilePicture { get; set; }
    }
}
