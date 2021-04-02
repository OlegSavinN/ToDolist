using MediatR;
using System;

namespace ToDoList.Application.Queries.RemoveToDoList
{
    public class RemoveToDoItemListCommand : IRequest
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
    }
}
