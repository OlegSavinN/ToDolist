using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Application.Commands.AddUser;
using ToDoList.Application.Commands.UpdateUser;
using ToDoList.Application.Commands.RemoveUser;
using ToDoList.Core;
using ToDoList.Application.Commands.AddToDoList;
using ToDoList.Application.Commands.AddToDoItem;
using ToDoList.Application.Commands.UpdateToDoList;
using ToDoList.Application.Commands.RemoveToDoList;
using ToDoList.Application.Commands.UpdateToDoItem;
using ToDoList.Application.Commands.RemoveToDoItem;
using ToDoList.Application.Commands.GetUser;
using ToDoList.Application.Commands.GetToDoList;
using ToDoList.Application.Commands.GetToDoItem;
using ToDoList.Application.Commands.GetToken;

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
            [FromBody] User user)
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

        [HttpDelete]
        public async Task RemoveUser(
            [FromBody] User user)
        {
            var command = new RemoveUserCommand(user);
            await _mediator.Send(command);
        }

        [HttpGet]
        public async Task GetUser(
            [FromBody] User user)
        {
            var command = new GetUserCommand(user);
            await _mediator.Send(command);
        }

        [HttpPost("Token")]
        public async Task GetToken(
            [FromBody] User user)
        {
            var command = new GetTokenCommand(user);
            await _mediator.Send(command);
        }

        [HttpPost("ToDoItemlists")]
        public async Task AddToDoItemList(
            [FromBody] ToDoItemsList toDoItemList)
        {
            var command = new AddToDoItemListCommand(toDoItemList);
            await _mediator.Send(command);
        }

        [HttpPut("ToDoItemlists")]
        public async Task UpdatedToDoItemList(
            [FromBody] ToDoItemsList toDoItemList)
        {
            var command = new UpdateToDoItemListCommand(toDoItemList);
            await _mediator.Send(command);
        }

        [HttpDelete("ToDoItemLists")]
        public async Task RemoveToDoItemsList(
            [FromBody] ToDoItemsList toDoItemsList)
        {
            var command = new RemoveToDoItemListCommand(toDoItemsList);
            await _mediator.Send(command);
        }

        [HttpGet("ToDoItemLists")]
        public async Task GetToDoItemsList(
            [FromBody] User user)
        {
            var command = new GetToDoItemListCommand(user);
            await _mediator.Send(command);
        }


        [HttpPost("ToDoItem")]
        public async Task AddToDoItem(
            [FromBody] ToDoItem toDoItem)
        {
            var command = new AddToDoItemCommand(toDoItem);
            await _mediator.Send(command);
        }

        [HttpPut("ToDoItem")]
        public async Task UpdateToDoItem(
            [FromBody] ToDoItem toDoItem)
        {
            var command = new UpdateToDoItemCommand(toDoItem);
            await _mediator.Send(command);
        }

        [HttpDelete("ToDoItem")]
        public async Task RemoveToDoItem(
            [FromBody] ToDoItem toDoItem)
        {
            var command = new RemoveToDoItemCommand(toDoItem);
            await _mediator.Send(command);
        }

        [HttpGet("ToDoItem")]
        public async Task GetToDoItem(
            [FromBody] ToDoItemsList toDoItemsList)
        {
            var command = new GetToDoItemCommand(toDoItemsList);
            await _mediator.Send(command);
        }
    }
}
