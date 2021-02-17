using MediatR;
using System;
using ToDoList.Core;

namespace ToDoList.Application.Queries.GetToDoList
{
    public class GetToDoItemListQuery : IRequest<ToDoItemsList[]>
    {
        public Guid UserId { get; }
        public GetToDoItemListQuery(User user)
        {
            UserId = user.Id;
        }
    }
}
