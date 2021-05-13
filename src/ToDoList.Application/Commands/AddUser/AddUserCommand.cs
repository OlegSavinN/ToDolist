using MediatR;
using System;
using ToDoList.Core.Models;

namespace ToDoList.Application.Queries.AddUser
{
    public class AddUserCommand : IRequest
    {
        public Guid Id { get; set; }

        public UserModel UserModel { get; set; }
    }
}
