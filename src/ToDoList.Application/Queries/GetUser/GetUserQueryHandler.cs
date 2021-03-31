using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using ToDoList.Core;
using ToDoList.Infrastructure.Persistence.Contexts;

namespace ToDoList.Application.Queries.GetUser
{
    class GetUserQueryHandler : IRequestHandler<GetUserQuery, User>
    {
        private readonly DatabaseContext _storage;

        public GetUserQueryHandler(
            DatabaseContext storage)
        {
            _storage = storage;
        }
        public async Task<User> Handle(
            GetUserQuery query,
            CancellationToken cancellationToken)
        {
            User user = await _storage.Users.FirstOrDefaultAsync(
                x => x.Login == query.Login && x.Password == query.Password, 
                cancellationToken);

            return user;
        }
    }
}
