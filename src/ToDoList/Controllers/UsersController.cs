using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Application.Commands.AddUser;
using ToDoList.Core;

namespace ToDoList.Controllers
{
    [ApiController]
    [Route("users")]
    public class UsersController
    {
        private readonly IMediator _mediator;

        public UsersController(
            IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task AddUser(User user)
        {
            var command = new AddUserCommand(user);
            await _mediator.Send(command);
        }
    }
}
