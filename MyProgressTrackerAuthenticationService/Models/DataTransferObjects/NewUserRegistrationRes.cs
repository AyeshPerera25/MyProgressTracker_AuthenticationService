using MyProgressTrackerAuthenticationService.Models.Entities;

namespace MyProgressTrackerAuthenticationService.Models.DataTransferObjects
{
    public class NewUserRegistrationRes : ResponseWrapper
    {
        public NewUserRegistrationReq? NewUserRegistrationReq { get; set; }
        public User? User { get; set; }
    }
}
