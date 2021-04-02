using MediatR;
using System;

namespace ToDoList.Application.Queries.AddToDoList
{
    public class AddToDoItemListCommand : IRequest
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }

        public string Name { get; set; }
    }
}
