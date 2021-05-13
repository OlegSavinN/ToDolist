using MediatR;
using System;
using ToDoList.Core.Models;

namespace ToDoList.Application.Queries.RemoveUser
{
    public class RemoveUserCommand : IRequest
    {
        public Guid Id { get; set; }

        public string Login { get; set; }

        public UserModel UserModel { get; set; }
    }
}
