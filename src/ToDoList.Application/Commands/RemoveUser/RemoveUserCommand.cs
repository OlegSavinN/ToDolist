using MediatR;
using System;
using ToDoList.Core;

namespace ToDoList.Application.Queries.RemoveUser
{
    public class RemoveUserCommand : IRequest
    {
        public Guid UserId { get; }

        public RemoveUserCommand(User user)
        {
            UserId = user.Id;
        }
    }
}
