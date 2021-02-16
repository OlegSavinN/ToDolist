using MediatR;
using System;
using ToDoList.Core;

namespace ToDoList.Application.Commands.GetToDoItem
{
    public class GetToDoItemCommand : IRequest
    {
        public Guid ListId { get; }
        public GetToDoItemCommand(ToDoItemsList toDoItemsList)
        {
            ListId = toDoItemsList.Id;
        }
    }
}
