using MediatR;
using System;
using ToDoList.Core;

namespace ToDoList.Application.Commands.GetToDoList
{
    public class GetToDoItemListCommand : IRequest
    {
        public Guid UserId { get; }
        public GetToDoItemListCommand(User user)
        {
            UserId = user.Id;
        }
    }
}
