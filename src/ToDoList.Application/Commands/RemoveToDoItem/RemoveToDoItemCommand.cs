using MediatR;
using System;
using ToDoList.Core;

namespace ToDoList.Application.Commands.RemoveToDoItem
{
    public class RemoveToDoItemCommand : IRequest
    {
        public Guid ToDoItemId { get; }
        public RemoveToDoItemCommand(ToDoItem toDoItem)
        {
            ToDoItemId = toDoItem.Id;
        }
    }
}
