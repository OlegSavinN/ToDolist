using MediatR;
using ToDoList.Core;

namespace ToDoList.Application.Queries.AddUser
{
    public class AddUserCommand : IRequest
    {
        public User User { get; }

        public AddUserCommand(User user)
        {
            User = user;
        }
    }
}
