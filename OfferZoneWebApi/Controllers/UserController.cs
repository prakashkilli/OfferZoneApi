using DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfferZoneWebApi.BL;
using OfferZoneWebApi.Models;

namespace OfferZoneWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost]
        public IActionResult getUser([FromForm]string Email,[FromForm]string PassWord)
        {
            List<User> user = UserBl.GetUsers(Email, PassWord);
            return Ok(user);
        }

        [HttpPost("Register")]
        public IActionResult registerUser(User user)
        {
            var RegisterUser = UserBl.registerUser(user);
            return Ok(RegisterUser);
        }

    }
}
