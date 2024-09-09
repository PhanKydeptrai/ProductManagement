using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.Application.Feature.CreateNewUser;
using ProductManagement.Application.Feature.GetAllUser;
using ProductManagement.Application.Feature.GetUserByName;
using ProductManagement.Application.Feature.Login;
using ProductManagement.Application.Feature.Register;
using ProductManagement.Domain.IRepositories;

namespace ProductManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ISender _sender;
        public UserController(ISender sender)
        {
            _sender = sender;
        }
        [HttpGet]
        public async Task<IActionResult> Users()
        {
            GetAllUserQuery request = new GetAllUserQuery();
            var result = await _sender.Send(request);
            if(result.IsSuccess)
            {
                return Ok(result.Value);
            }
            return NotFound("No user found");
        }

        [HttpPost]
        public async Task<IActionResult> User(CreateNewUserCommand request)
        {
            var result = await _sender.Send(request);
            if(result.IsSuccess)
            {
                return Ok("User created successfully");
            }
            return BadRequest(result.Errors);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterCommand request)
        {
            var result = await _sender.Send(request);
            if(result.IsSuccess)
            {
                return Ok("User registered successfully");
            }
            return BadRequest(result.Errors);
        }

        //Api dùng để tìm kiếm user theo tên
        [HttpGet("Search")]
        public async Task<IActionResult> SeachUser([FromQuery]string? searchString)
        {
            GetUserByNameQuery request = new GetUserByNameQuery
            {
                UserName = searchString
            };

            var result = await _sender.Send(request);
            return Ok(result.Value);

        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginCommand request)
        {
            var result = await _sender.Send(request);
            if(result.IsSuccess)
            {
                //Return token
                return Ok(result.Value);
            }
            return BadRequest("Login failed");
        }
    }
}
