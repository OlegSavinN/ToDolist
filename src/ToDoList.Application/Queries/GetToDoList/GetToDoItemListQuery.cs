using MediatR;
using System;
using System.Collections.Generic;
using ToDoList.Core.Entities;

namespace ToDoList.Application.Queries.GetToDoList
{
    public class GetToDoItemListQuery : IRequest<List<ToDoItemsList>>
    {
        public Guid UserId { get; set; }
    }
}
