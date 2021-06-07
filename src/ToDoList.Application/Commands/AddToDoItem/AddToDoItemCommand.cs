using MediatR;
using System;
using ToDoList.Core.Models;

namespace ToDoList.Application.Queries.AddToDoItem
{
    public class AddToDoItemCommand : IRequest
    {
        public Guid UserId { get; set; }

        public Guid ListId { get; set; }

        public ToDoItemModel ToDoItemModel { get; set; }
    }
}
