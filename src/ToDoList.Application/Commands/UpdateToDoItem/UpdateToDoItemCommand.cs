using MediatR;
using System;
using ToDoList.Core.Models;

namespace ToDoList.Application.Queries.UpdateToDoItem
{
    public class UpdateToDoItemCommand : IRequest
    {
        public Guid UserId { get; set; }

        public Guid ListId { get; set; }
        public Guid ItemId { get; set; }

        public DateTime Date { get; set; }

        public ToDoItemModel ToDoItemModel { get; set; }
    }
}
