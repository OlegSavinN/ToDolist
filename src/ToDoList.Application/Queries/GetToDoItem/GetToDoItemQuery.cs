using MediatR;
using System;
using ToDoList.Core;

namespace ToDoList.Application.Queries.GetToDoItem
{
    public class GetToDoItemQuery : IRequest<ToDoItem[]>
    {
        public Guid ListId { get; }
        public GetToDoItemQuery(ToDoItemsList toDoItemsList)
        {
            ListId = toDoItemsList.Id;
        }
    }
}
