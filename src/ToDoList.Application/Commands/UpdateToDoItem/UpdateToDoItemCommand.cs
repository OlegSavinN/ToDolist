using MediatR;
using ToDoList.Core;

namespace ToDoList.Application.Queries.UpdateToDoItem
{
    public class UpdateToDoItemCommand : IRequest
    {
        public ToDoItem ToDoItem { get; }
        public UpdateToDoItemCommand(ToDoItem toDoItem)
        {
            ToDoItem = toDoItem;
        }
    }
}
