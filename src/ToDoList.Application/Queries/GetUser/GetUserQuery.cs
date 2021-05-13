using MediatR;
using ToDoList.Core.Entities;

namespace ToDoList.Application.Queries.GetUser
{
    public class GetUserQuery : IRequest<User>
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
