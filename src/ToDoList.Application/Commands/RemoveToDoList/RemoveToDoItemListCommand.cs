using MediatR;
using System;
using ToDoList.Core;

namespace ToDoList.Application.Commands.RemoveToDoList
{
    public class RemoveToDoItemListCommand : IRequest
    {   
        public Guid ListGuid { get; }

        public RemoveToDoItemListCommand(ToDoItemsList list)
        {
            ListGuid = list.Id;
        }
    }
}
