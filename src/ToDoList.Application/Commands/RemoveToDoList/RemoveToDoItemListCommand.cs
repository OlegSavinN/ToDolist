using MediatR;
using ToDoList.Core;

namespace ToDoList.Application.Queries.RemoveToDoList
{
    public class RemoveToDoItemListCommand : IRequest
    {   
        public ToDoItemsList List { get; }

        public RemoveToDoItemListCommand(ToDoItemsList list)
        {
            List = list;
        }
    }
}
