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
using ToDoList.DTO;
using System.Collections.Generic;
using AutoMapper;
using System;

namespace ToDoList.Controllers
{
    [ApiController]
    [Route("api/v1/users")]
    [Authorize(Roles = "Admin, User, Vip")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UsersController(
            IMediator mediator,
            IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
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
        public async Task<UserDTO> GetUser(
            [FromBody]  UserDTO userRequest)
        {
            var query = _mapper.Map<GetUserQuery>(userRequest);
            User user = await _mediator.Send(query);
            var responce = _mapper.Map<UserDTO>(user);

            return responce;
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
        public async Task<List<ToDoItemsList>> GetToDoItemsList(
            [FromBody] User user)
        {
            var command = new GetToDoItemListQuery(user);
            List<ToDoItemsList> toDoItemsLists =  await _mediator.Send(command);
            return toDoItemsLists;
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
            [FromBody] ToDoItemDTO toDoItemDTO)
        {
            var command = _mapper.Map<UpdateToDoItemCommand>(toDoItemDTO);
            command.UserId = Guid.Parse(User.FindFirst("UserId").Value);
            await _mediator.Send(command);
        }

        [HttpDelete("ToDoItem")]
        public async Task RemoveToDoItem(
            [FromBody] ToDoItemDTO toDoItemDTO)
        {
            var command = _mapper.Map<RemoveToDoItemCommand>(toDoItemDTO);
            command.UserId = Guid.Parse(User.FindFirst("UserId").Value);
            await _mediator.Send(command);
        }

        [HttpGet("ToDoItem")]
        public async Task<List<ToDoItem>> GetToDoItem(
            [FromBody] User user)
        {
            var command = new GetToDoItemQuery(user);
            List<ToDoItem> toDoItem = await _mediator.Send(command);

            return toDoItem;
        }
    }
}
