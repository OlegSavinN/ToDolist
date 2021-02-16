using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ToDoList.Core;
using ToDoList.Application.Commands.GetToken;

namespace ToDoList.Controllers
{
    [ApiController]
    [Route("Auth")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<string> GetToken(
            [FromBody] User user)
        {
            var command = new GetTokenCommand(user);
            var token = await _mediator.Send(command);

            return token;
        }
    }
}
