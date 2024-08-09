using Messanger.Api.Contracts;
using Messanger.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace Messanger.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersServices userServices;

        public UsersController(IUsersServices userServices)
        {
            this.userServices = userServices;
        }


        [HttpGet]
        public async Task<ActionResult<List<UsersResponse>>> GetUsers()
        {
            var users = await userServices.GetAllUsers();
            var response = users.Select(b => new UsersResponse(b.id, b.username , b.password, b.email)).ToList();
            return Ok(response);
        }
    }
}
