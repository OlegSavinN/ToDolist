using MediatR;
using ToDoList.Core;

namespace ToDoList.Application.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest
    {
        public User User {get;}

        public UpdateUserCommand(User user)
        {
            User = user;
        }
    }
}
