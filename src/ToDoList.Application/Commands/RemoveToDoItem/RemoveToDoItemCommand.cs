using MediatR;
using System;

namespace ToDoList.Application.Queries.RemoveToDoItem
{
    public class RemoveToDoItemCommand : IRequest
    {

        public Guid UserId { get; set; }

        public Guid Id { get; set; }

        public Guid ListId { get; set; }
    }
}
