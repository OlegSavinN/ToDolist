using MediatR;
using System;

namespace ToDoList.Application.Queries.UpdateToDoList
{
    public class UpdateToDoItemListCommand : IRequest
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }

        public string Name { get; set; }
    }
}
