using System.ComponentModel.DataAnnotations;

namespace MyProgressTrackerAuthenticationService.Models.DataTransferObjects
{
    public class NewUserRegistrationReq : RequestWrapper
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
