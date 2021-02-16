using MediatR;
using ToDoList.Core;

namespace ToDoList.Application.Commands.GetToken
{
    public class GetTokenCommand : IRequest
    {
        public string UserLogin { get; }
        public string UserPassword { get; }

        public GetTokenCommand(User user)
        {
            UserLogin = user.Login;
            UserPassword = user.Password;
        }
    }
}
