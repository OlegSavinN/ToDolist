using MediatR;
using System;
using System.Collections.Generic;
using ToDoList.Core.Entities;

namespace ToDoList.Application.Queries.GetToDoItem
{
    public class GetToDoItemQuery : IRequest<List<ToDoItem>>
    {
        public Guid UserId { get; }
        public GetToDoItemQuery(User user)
        {
            UserId = user.Id;
        }
    }
}
