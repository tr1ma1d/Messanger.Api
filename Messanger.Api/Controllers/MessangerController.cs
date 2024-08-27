using Messanger.Api.Contracts;
using Messanger.Services.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Messanger.Api.Controllers
{
    [ApiController]
    [Route("messangers/[controller]")]
    public class MessangerController : ControllerBase
    {
        private readonly IUsersServices userServices;
        public MessangerController(IUsersServices userServices)
        {
            this.userServices = userServices;
        }

        [HttpGet("groups")]
        public async Task<ActionResult<List<GroupsResponse>>> GetChannels()
        {
            return Ok();
        }
        [HttpGet("groups/search)"]
        public async Task<ActionResult<GroupsResponse>> GetGroupById([FromQuery] string name)
        {
            var group = await userServices.Get(name); // Пример вызова сервиса
            if (group == null)
            {
                return NotFound();
            }
            return Ok(group);
        }
        [HttpPost("create-group")]
        public async Task<ActionResult<int>> AddGroup([FromBody] GroupRequest request)
        {
            return Ok();
        }
        [HttpDelete("remove-user/{username}")]
        public async Task<ActionResult> RemoveUser(string username)
        {
            var success = await userServices.RemoveUserByUsernameAsync(username); // Удаление по username
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }

    }
}
