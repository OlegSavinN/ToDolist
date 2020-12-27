using MediatR;
using ToDoList.Core;

namespace ToDoList.Application.Commands.AddUser
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
