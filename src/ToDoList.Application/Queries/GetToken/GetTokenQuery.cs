using MediatR;
using ToDoList.Core;

namespace ToDoList.Application.Queries.GetToken
{
    public class GetTokenQuery : IRequest<string>
    {
        public string UserLogin { get; }
        public string UserPassword { get; }

        public GetTokenQuery(User user)
        {
            UserLogin = user.Login;
            UserPassword = user.Password;
        }
    }
}
