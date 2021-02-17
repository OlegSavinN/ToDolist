using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ToDoList.Application.Services;
using ToDoList.Core;

namespace ToDoList.Application.Queries.GetUser
{
    class GetUserQueryHandler : IRequestHandler<GetUserQuery, User>
    {
        private readonly IDataAccess _dataAccess;

        public GetUserQueryHandler(
            IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        public async Task<User> Handle(
            GetUserQuery query,
            CancellationToken cancellationToken)
        {
            User user = await _dataAccess.GetUser(query.UserLogin, query.UserPassword);
            return user;
        }
    }
}
