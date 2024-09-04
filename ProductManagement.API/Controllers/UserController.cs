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
        
        private readonly ISender _sender;
        public UserController(ISender sender)
        {
            _sender = sender;
        }



        

        [HttpPost]
        public async Task<IActionResult> AddNewUser(CreateNewUserCommand request)
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
