using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MyProgressTrackerAuthenticationService.Models.DataTransferObjects;
using MyProgressTrackerAuthenticationService.Services;

namespace MyProgressTrackerAuthenticationService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAuthenticationController : Controller
    {
        private SystemAuthenticationServiceCore _serviceCore;

        public UserAuthenticationController(SystemAuthenticationServiceCore serviceCore)
        {
            _serviceCore = serviceCore;
        }

        [HttpPost("userRegister")]
        public ActionResult<NewUserRegistrationRes> UserRegister(NewUserRegistrationReq request)
        {
            try 
            {
                return Ok(_serviceCore.UserRegistration(request));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        } 
    }
}
