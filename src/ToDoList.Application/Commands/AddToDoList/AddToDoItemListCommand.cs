using MediatR;
using ToDoList.Core;

namespace ToDoList.Application.Queries.AddToDoList
{
    public class AddToDoItemListCommand : IRequest
    {
        public ToDoItemsList ToDoItemsList { get; }

        public AddToDoItemListCommand(
            ToDoItemsList toDoItemsList)
        {
            ToDoItemsList = toDoItemsList;
        }
    }
}
