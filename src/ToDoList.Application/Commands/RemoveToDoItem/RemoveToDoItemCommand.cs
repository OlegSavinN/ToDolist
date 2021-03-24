using MediatR;
using ToDoList.Core;

namespace ToDoList.Application.Queries.RemoveToDoItem
{
    public class RemoveToDoItemCommand : IRequest
    {
        public ToDoItem ToDoItem { get; }

        public RemoveToDoItemCommand(ToDoItem toDoItem)
        {
            ToDoItem = toDoItem;
        }
    }
}
