using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ToDoList.Application.Services;
using ToDoList.Core;

namespace ToDoList.Application.Commands.GetUser
{
    class GetUserQueryHandler : IRequestHandler<GetUserCommand, User>
    {
        private readonly IDataAccess _dataAccess;

        public GetUserQueryHandler(
            IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        public async Task<User> Handle(
            GetUserCommand query,
            CancellationToken cancellationToken)
        {
            User user = await _dataAccess.GetUser(query.UserLogin, query.UserPassword);
            return user;
        }
    }
}
