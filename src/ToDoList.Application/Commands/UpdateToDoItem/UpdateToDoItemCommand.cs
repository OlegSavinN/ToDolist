using MediatR;
using ToDoList.Core;

namespace ToDoList.Application.Commands.UpdateToDoItem
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
