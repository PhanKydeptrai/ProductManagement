using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.Application.Feature.CreateNewUser;
using ProductManagement.Application.Feature.GetAllUser;
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
    }
}
