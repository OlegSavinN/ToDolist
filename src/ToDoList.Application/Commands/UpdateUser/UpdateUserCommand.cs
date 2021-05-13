using MediatR;
using System;
using ToDoList.Core.Models;

namespace ToDoList.Application.Queries.UpdateUser
{
    public class UpdateUserCommand : IRequest
    {
        public Guid Id { get; set; }

        public string Login { get; set; }

        public UserModel UserModel { get; set; }
    }
}
