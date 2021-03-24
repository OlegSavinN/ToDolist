using MediatR;
using ToDoList.Core;

namespace ToDoList.Application.Queries.AddToDoItem
{
    public class AddToDoItemCommand : IRequest
    {
        public ToDoItem ToDoItem { get; }

        public AddToDoItemCommand(
            ToDoItem toDoItem)
        {
            ToDoItem = toDoItem;
        }
    }
}
