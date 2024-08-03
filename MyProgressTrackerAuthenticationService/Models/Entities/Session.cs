using System.ComponentModel.DataAnnotations;

namespace MyProgressTrackerAuthenticationService.Models.Entities
{
    public class Session
    {
        public Session()
        {
        }

        public Session(long sessionId, string sessionKey, long userId, User user, DateTime lastLoginTime, bool loginStatus)
        {
            SessionId = sessionId;
            SessionKey = sessionKey;
            UserId = userId;
            User = user;
            LastLoginTime = lastLoginTime;
            LoginStatus = loginStatus;
        }

        [Key]
        [Required]
        public long SessionId { get; set; }
        [Required]
        public string SessionKey { get; set; }
        [Required]
        public long UserId { get; set; }
        [Required]
        public User User { get; set; }
        [Required]
        public DateTime LastLoginTime { get; set; }
        [Required]
        public bool LoginStatus { get; set; }   
    }

    

}
