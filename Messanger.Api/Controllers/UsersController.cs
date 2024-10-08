﻿using Messanger.Api.Contracts;
using Messanger.Services.Services;
using Microsoft.AspNetCore.Mvc;
using Messanger.Core.Models;

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
            var response = users.Select(b => new UsersResponse(b.username , b.password, b.email)).ToList();
            return Ok(response);
        }
        [HttpPost("register")]
        public async Task<ActionResult<int>> AddUser([FromBody] UsersRequest request)
        {
            var (user, error) = Core.Models.User.Create(
                                                request.Username,
                                                request.Password,
                                                request.Email);

            if (!string.IsNullOrEmpty(error))
            {
                return BadRequest(error);
            }

            await userServices.CreateUser(user);

            return Ok(user.id);
        }

        [HttpPost("login")]
        public async Task<ActionResult<int>> LoginUser([FromBody] UsersLoginResponse request)
        {
            bool users = await userServices.ValidateUser(request.Username, request.Password);
            if(users == false)
            {
                return Unauthorized(new { message = "Invalid username or password" });
            
            }

            return Ok(new { message = "Login successful" });
        }

    }
}
