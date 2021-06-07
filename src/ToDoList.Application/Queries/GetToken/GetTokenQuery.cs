using MediatR;

namespace ToDoList.Application.Queries.GetToken
{
    public class GetTokenQuery : IRequest<string>
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
