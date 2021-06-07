using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoList.Application.Queries.AddToDoItem;
using ToDoList.Application.Queries.GetToDoItem;
using ToDoList.Application.Queries.RemoveToDoItem;
using ToDoList.Application.Queries.UpdateToDoItem;
using ToDoList.Core.Entities;
using ToDoList.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ToDoList.Filters;

namespace ToDoList.Controllers
{
    [ApiController]
    [SetIdFilter]
    [Route("api/v1/ToDoItem")]
    [Authorize(Roles = "Admin, User, Vip")]
    public class ToDoItemController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ToDoItemController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task AddToDoItem(
            [FromBody] ToDoItemDTO toDoItem)
        {
            var command = _mapper.Map<AddToDoItemCommand>(toDoItem);
            command.UserId = Guid.Parse(User.FindFirst("UserId").Value);
            await _mediator.Send(command);
        }

        [HttpPut]
        public async Task UpdateToDoItem(
            [FromBody] ToDoItemDTO toDoItemDTO)
        {
            var command = _mapper.Map<UpdateToDoItemCommand>(toDoItemDTO);
            command.UserId = Guid.Parse(User.FindFirst("UserId").Value);
            await _mediator.Send(command);
        }

        [HttpDelete]
        public async Task RemoveToDoItem(
            [FromBody] ToDoItemDTO toDoItemDTO)
        {
            var command = _mapper.Map<RemoveToDoItemCommand>(toDoItemDTO);
            command.UserId = Guid.Parse(User.FindFirst("UserId").Value);
            await _mediator.Send(command);
        }

        [HttpGet]
        public async Task<List<ToDoItem>> GetToDoItem(
            [FromBody] User user)
        {
            var command = new GetToDoItemQuery(user);
            List<ToDoItem> toDoItem = await _mediator.Send(command);

            return toDoItem;
        }
    }
}
