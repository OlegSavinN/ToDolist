using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Application.Queries.AddUser;
using ToDoList.Application.Queries.UpdateUser;
using ToDoList.Application.Queries.RemoveUser;
using ToDoList.Application.Queries.GetUser;
using ToDoList.DTO;
using AutoMapper;
using System;
using ToDoList.Core.Entities;
using ToDoList.Filters;

namespace ToDoList.Controllers
{
    [ApiController]
    [SetIdFilter]
    [Route("api/v1/users")]
    //[Authorize(Roles = "Admin, User, Vip")]
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
            [FromBody] UserDTO userDTO)
        {
            var command = _mapper.Map<AddUserCommand>(userDTO);
            await _mediator.Send(command);
        }

        [HttpPut]
        public async Task UpdateUser(
            [FromBody] UserDTO userDTO)
        {
            var command = _mapper.Map<UpdateUserCommand>(userDTO);
            command.Id = Guid.Parse(User.FindFirst("UserId").Value);
            await _mediator.Send(command);
        }

        [HttpDelete]
        public async Task RemoveUser(
            [FromBody] UserDTO userDTO)
        {
            var command = _mapper.Map<RemoveUserCommand>(userDTO);
            command.Id = Guid.Parse(User.FindFirst("UserId").Value);
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
    }
}
