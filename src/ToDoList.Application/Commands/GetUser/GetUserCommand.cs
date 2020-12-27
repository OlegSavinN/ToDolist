using MediatR;
using ToDoList.Core;

namespace ToDoList.Application.Commands.GetUser
{
    public class GetUserCommand : IRequest
    {
        public string UserLogin { get; }
        public string UserPassword { get; }

        public GetUserCommand(User user)
        {
            UserLogin = user.Login;
            UserPassword = user.Password;
        }
    }
}
