using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ToDoList.Core;
using ToDoList.Application.Queries.GetToken;
using ToDoList.DTO;

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
        public async Task<AuthResultDto> GetToken(
            [FromBody] User user)
        {
            var query = new GetTokenQuery(user);
            AuthResultDto token = new AuthResultDto();
            token.AccessToken = await _mediator.Send(query);
            return token;
        }
    }
}
