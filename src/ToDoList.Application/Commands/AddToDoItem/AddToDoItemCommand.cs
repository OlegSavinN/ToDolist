using MediatR;
using System;

namespace ToDoList.Application.Queries.AddToDoItem
{
    public class AddToDoItemCommand : IRequest
    {
        public Guid UserId { get; set; }

        public Guid Id { get; set; }

        public Guid ListId { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public string Priority { get; set; }
        public string State { get; set; }
    }
}
