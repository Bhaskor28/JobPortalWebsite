using JobPortal.Application.Users;
using JobPortal.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JobPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        // GET: api/<UsersController>
        [HttpGet]
        public ActionResult<List<User>> GetAll()
        {
            var item = _userService.GetAllUsers();
            return Ok(item);
        }
        [HttpPost]
        public ActionResult<User> PostUser(User user)
        {
            _userService.CreateUser(user);
            return Ok(user);
        }
       
    }
}
