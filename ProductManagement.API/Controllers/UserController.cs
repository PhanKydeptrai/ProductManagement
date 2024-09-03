using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.Application.Feature.CreateNewUser;
using ProductManagement.Domain.IRepositories;

namespace ProductManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly ISender _sender;
        public UserController(IUserRepository userRepository, ISender sender)
        {
            _userRepository = userRepository;
            _sender = sender;
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
