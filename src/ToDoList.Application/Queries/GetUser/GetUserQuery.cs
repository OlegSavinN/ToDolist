using MediatR;
using ToDoList.Core;

namespace ToDoList.Application.Queries.GetUser
{
    public class GetUserQuery : IRequest<User>
    {
        public string UserLogin { get; }
        public string UserPassword { get; }

        public GetUserQuery(User user)
        {
            UserLogin = user.Login;
            UserPassword = user.Password;
        }
        //public AuthResultDto Token { get; }

        //public GetUserQuery(AuthResultDto result)
        //{
        //    Token = result;
        //}
    }
}
