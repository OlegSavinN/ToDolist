using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoList.Application.Queries.AddToDoList;
using ToDoList.Application.Queries.GetToDoList;
using ToDoList.Application.Queries.RemoveToDoList;
using ToDoList.Application.Queries.UpdateToDoList;
using ToDoList.Core.Entities;
using ToDoList.DTO;
using ToDoList.Filters;

namespace ToDoList.Controllers
{
    [ApiController]
    [SetIdFilter]
    [Route("api/v1/ToDoItemlists")]
    [Authorize(Roles = "Admin, User, Vip")]
    public class ToDoItemListController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ToDoItemListController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task AddToDoItemList(
            [FromBody] ToDoItemsListDTO toDoItemListDTO)
        {
            var command = _mapper.Map<AddToDoItemListCommand>(toDoItemListDTO);
           // command.UserId = Guid.Parse(User.FindFirst("UserId").Value);
            await _mediator.Send(command);
        }

        [HttpPut]
        public async Task UpdatedToDoItemList(
            [FromBody] ToDoItemsListDTO toDoItemListDTO)
        {
            var command = _mapper.Map<UpdateToDoItemListCommand>(toDoItemListDTO);
            command.UserId = Guid.Parse(User.FindFirst("UserId").Value);
            await _mediator.Send(command);
        }

        [HttpDelete]
        public async Task RemoveToDoItemsList(
            [FromBody] ToDoItemsListDTO toDoItemsList)
        {
            var command = _mapper.Map<RemoveToDoItemListCommand>(toDoItemsList);
            //command.UserId = Guid.Parse(User.FindFirst("UserId").Value);
            await _mediator.Send(command);
        }

        [HttpGet]
        public async Task<List<ToDoItemsList>> GetToDoItemsList(
            [FromBody] ToDoItemsListDTO toDoItemsList)
        {
            var command = _mapper.Map<GetToDoItemListQuery>(toDoItemsList);
            //command.UserId = Guid.Parse(User.FindFirst("UserId").Value);
            List<ToDoItemsList> toDoItemsLists = await _mediator.Send(command);
            return toDoItemsLists;
        }
    }
}
