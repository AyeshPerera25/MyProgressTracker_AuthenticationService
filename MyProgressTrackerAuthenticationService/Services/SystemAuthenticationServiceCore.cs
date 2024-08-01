using MyProgressTrackerAuthenticationService.Handlers;
using MyProgressTrackerAuthenticationService.Models.DataTransferObjects;

namespace MyProgressTrackerAuthenticationService.Services
{
    public class SystemAuthenticationServiceCore
    {
        private UserRegistrationHandler _userRegistrationHandler;
        private UserLoginHandler _userLoginHandler;

        public SystemAuthenticationServiceCore(UserLoginHandler userLoginHandler, UserRegistrationHandler userRegistrationHandler)
        {
            _userLoginHandler = userLoginHandler;
            _userRegistrationHandler = userRegistrationHandler; 
        }

        public NewUserRegistrationRes UserRegistration(NewUserRegistrationReq request)
        {
            NewUserRegistrationRes response = null;
            try
            {
                response = _userRegistrationHandler.Register(request);
            }
            catch (Exception ex)
            {
                response = new NewUserRegistrationRes();
                response.IsRequestSuccess = false;
                response.Description = ex.Message;
            }
            return response;
        }

        public UserLoginRes UserLogin(UserLoginReq request)
        {
            UserLoginRes response = null;
            try
            {
               
            }
            catch (Exception ex)
            {
                response = new UserLoginRes();
                response.IsRequestSuccess = false;
                response.Description = ex.Message;
            }
            return response;
        }
    }
}
