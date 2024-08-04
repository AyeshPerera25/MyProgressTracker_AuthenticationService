using Azure.Core;
using MyProgressTrackerAuthenticationService.DataResources;
using MyProgressTrackerDependanciesLib.Models.DataTransferObjects;
using MyProgressTrackerDependanciesLib.Models.Entities;

namespace MyProgressTrackerAuthenticationService.Handlers
{
    public class UserLoginHandler
    {
        private readonly AzuerSQLDBContext _dbContext;

        public UserLoginHandler(AzuerSQLDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public UserLoginRes Login(UserLoginReq request) 
        {
            UserLoginRes response = null;
            Session session = null;
            User user = validateLoginRequest(request);
			session = populateLoginSession(user);
            persistLoginSession(session);

            response = new UserLoginRes();
            response.IsRequestSuccess = true;
            response.Description = "Success!";
            response.UserId = user.UserId;
            response.SessionKey = session.SessionKey;

            return response;
        }

        private void persistLoginSession(Session? session)
        {
            if (session != null)
            {
                if(session.SessionId > 0L)
                {
                    _dbContext.Sessions.Update(session);
                }
                else
                {
                    _dbContext.Sessions.Add(session);

                }
                _dbContext.SaveChanges();
            }
            else
            {
                throw new Exception("Null Session Entity to persist");
            }
        }

        private Session populateLoginSession(User user)
        {
            Session session = null;
            DateTime localTime = DateTime.Now;
            long itimeCode = long.Parse(localTime.ToString("yyyyMMddHHmmss"));
            if (_dbContext.Sessions.Any())
            {
                session = _dbContext.Sessions.SingleOrDefault<Session>(ses => ses.UserId == user.UserId);
            }
            if (session == null)
            {
                session = new Session();
                session.User = user;
                session.UserId = user.UserId;
            }
            session.LoginStatus = true;
            session.SessionKey = user.FirstName + string.Concat(itimeCode) + user.LastName;
            session.LastLoginTime = localTime;
            return session;
        }

        private User validateLoginRequest(UserLoginReq request)
        {
            User? user = null;

            if (request == null)
            {
                throw new Exception("Login Request is null!");
            }
            if (_dbContext.Users.Any())
            {
                user = _dbContext.Users.SingleOrDefault<User>(user => user.Email == request.Email);
                if (user == null)
                {
                    throw new Exception("No user found under the mail: "+ request.Email);
                }
                if (user.Password != request.Password)
                {
                    throw new Exception("Incorrect Password! Try again");
                }
            }
            else
            {
                throw new Exception("No any User has registerd yet!");
            }

            return user;
        }
    }
}
