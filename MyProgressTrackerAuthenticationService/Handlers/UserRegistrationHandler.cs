using Microsoft.EntityFrameworkCore;
using MyProgressTrackerAuthenticationService.DataResources;
using MyProgressTrackerAuthenticationService.Models.DataTransferObjects;
using MyProgressTrackerAuthenticationService.Models.Entities;

namespace MyProgressTrackerAuthenticationService.Handlers
{
    public class UserRegistrationHandler
    {
        private readonly AzuerSQLDBContext _dbContext;

        public UserRegistrationHandler(AzuerSQLDBContext context)
        {
            _dbContext = context;
        }

        public NewUserRegistrationRes Register(NewUserRegistrationReq request)
        {
            NewUserRegistrationRes response = null;
            User? user = null;

            validateSignInModel(request);
            user = populateUser(request);
            persistUser(user);

            response = new NewUserRegistrationRes();
            response.IsRequestSuccess = true;
            response.Description = "Success!";
            response.NewUserRegistrationReq = request;
            response.User = user;

            return response;
        }

        private void persistUser(User? user)
        {
            if (user != null)
            {
                _dbContext.Users.Add(user);
                _dbContext.SaveChanges();
            }
            else
            {
                throw new Exception("Null User Entity to persist");
            }

        }

        private User populateUser(NewUserRegistrationReq request)
        {
            DateTime localTime = DateTime.Now;
            long id = long.Parse(localTime.ToString("yyyyMMddHHmmss"));
            return new User(id, request.FirstName, request.LastName, request.Email, request.Password);
        }

        private void validateSignInModel(NewUserRegistrationReq request)
        {
            User? user = null;


            if (request.Password != request.ConfirmPassword)
            {
                throw new Exception("The password and confirmation password do not match!");
            }
            if (_dbContext.Users.Any())
            {
                user = _dbContext.Users.SingleOrDefault<User>(user => user.Email == request.Email);
                if (user != null)
                {
                    throw new Exception("User already registerd under the email. Try another!");
                }
            }


        }
    }
}
