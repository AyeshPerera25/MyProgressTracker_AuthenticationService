namespace MyProgressTrackerAuthenticationService.Models.DataTransferObjects
{
    public class UserLoginReq : RequestWrapper
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
