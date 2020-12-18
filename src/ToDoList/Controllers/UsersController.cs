using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Application.Commands.AddUser;
using ToDoList.Application.Commands.UpdateUser;
using ToDoList.Core;

namespace ToDoList.Controllers
{
    [ApiController]
    [Route("users")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(
            IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task AddUser(
            [FromBody]User user)
        {
            var command = new AddUserCommand(user);
            await _mediator.Send(command);
        }

        [HttpPut]
        public async Task UpdateUser(
            [FromBody] User user)
        {
            var command = new UpdateUserCommand(user);
            await _mediator.Send(command);
        }
    }
}
