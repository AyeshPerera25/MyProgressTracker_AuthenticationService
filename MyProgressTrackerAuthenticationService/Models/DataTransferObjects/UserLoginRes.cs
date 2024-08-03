namespace MyProgressTrackerAuthenticationService.Models.DataTransferObjects
{
    public class UserLoginRes : ResponseWrapper
    {
        public string SessionKey { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public long UserId { get; set; }
    }
}
