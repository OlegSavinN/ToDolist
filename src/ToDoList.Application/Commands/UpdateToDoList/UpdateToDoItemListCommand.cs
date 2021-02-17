using MediatR;
using ToDoList.Core;

namespace ToDoList.Application.Queries.UpdateToDoList
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
