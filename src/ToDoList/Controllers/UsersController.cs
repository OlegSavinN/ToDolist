using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Application.Queries.AddUser;
using ToDoList.Application.Queries.UpdateUser;
using ToDoList.Application.Queries.RemoveUser;
using ToDoList.Core;
using ToDoList.Application.Queries.AddToDoList;
using ToDoList.Application.Queries.AddToDoItem;
using ToDoList.Application.Queries.UpdateToDoList;
using ToDoList.Application.Queries.RemoveToDoList;
using ToDoList.Application.Queries.UpdateToDoItem;
using ToDoList.Application.Queries.RemoveToDoItem;
using ToDoList.Application.Queries.GetUser;
using ToDoList.Application.Queries.GetToDoList;
using ToDoList.Application.Queries.GetToDoItem;
using Microsoft.AspNetCore.Authorization;

namespace ToDoList.Controllers
{
    [Authorize]
    [ApiController]
    [Route("users")]
    [Authorize(Roles = "Admin, User, Vip")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(
            IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        
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
            var command = new GetUserQuery(user);
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
            var command = new GetToDoItemListQuery(user);
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
            var command = new GetToDoItemQuery(toDoItemsList);
            await _mediator.Send(command);
        }
    }
}
