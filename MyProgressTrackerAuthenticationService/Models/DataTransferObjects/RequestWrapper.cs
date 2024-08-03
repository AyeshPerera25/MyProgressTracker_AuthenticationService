namespace MyProgressTrackerAuthenticationService.Models.DataTransferObjects
{
    public class RequestWrapper
    {
        public long? SessionId { get; set; }
        public string? SessionKey { get; set; }
		public long? UserId { get; set; }
	}
}
