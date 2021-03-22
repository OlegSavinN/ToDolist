using MediatR;
using ToDoList.Core;

namespace ToDoList.Application.Queries.RemoveUser
{
    public class RemoveUserCommand : IRequest
    {
        public User User { get; }

        public RemoveUserCommand(User user)
        {
            User = user;
        }
    }
}
