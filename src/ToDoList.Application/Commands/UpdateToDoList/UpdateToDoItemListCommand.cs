using MediatR;
using ToDoList.Core;

namespace ToDoList.Application.Commands.UpdateToDoList
{
    public class UpdateToDoItemListCommand : IRequest
    {
        public ToDoItemsList ToDoItemsList { get; }
        public UpdateToDoItemListCommand(
            ToDoItemsList toDoItemsList)
        {
            ToDoItemsList = toDoItemsList;
        }
    }
}
