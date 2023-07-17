using System.ComponentModel.DataAnnotations;

namespace GenericCourse.IdentityServer.DTOs
{
    public class SignupDTO
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
