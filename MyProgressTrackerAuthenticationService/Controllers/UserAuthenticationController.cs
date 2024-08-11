using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MyProgressTrackerDependanciesLib.Models.DataTransferObjects;
using MyProgressTrackerAuthenticationService.Services;

namespace MyProgressTrackerAuthenticationService.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
    public class UserAuthenticationController : Controller
	{
        private SystemAuthenticationServiceCore _serviceCore;

        public UserAuthenticationController(SystemAuthenticationServiceCore serviceCore)
        {
            _serviceCore = serviceCore;
        }

        [HttpPost("userRegister")]
        public ActionResult<NewUserRegistrationRes> UserRegister([FromBody] NewUserRegistrationReq request)
        {
            try 
            { 
                if (request == null)
                {
                    return BadRequest("Request is null");
                }
                return Ok(_serviceCore.UserRegistration(request));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("userLogin")]
        public ActionResult<UserLoginRes> UserLogin([FromBody] UserLoginReq request)
        {
            try
            {
                if (request == null)
                {
                    return BadRequest("Request is null");
                }
                return Ok(_serviceCore.UserLogin(request));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("userLogout")]
        public ActionResult<UserLogoutRes> UserLogout([FromBody] UserLogoutReq request)
        {
            try
            {
                if (request == null)
                {
                    return BadRequest("Request is null");
                }
                return Ok(_serviceCore.UserLogout(request));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
