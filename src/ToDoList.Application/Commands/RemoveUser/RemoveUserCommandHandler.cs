using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using ToDoList.Core.Entities;
using ToDoList.Infrastructure.Persistence.Contexts;

namespace ToDoList.Application.Queries.RemoveUser
{
    class RemoveUserCommandHandler : IRequestHandler<RemoveUserCommand>
    {
        private readonly DatabaseContext _storage;

        public RemoveUserCommandHandler(
            DatabaseContext storage)
        {
            _storage = storage;
        }

        public async Task<Unit> Handle(
            RemoveUserCommand command,
            CancellationToken cancellationToken)
        {
            User user = await _storage.Users
                .FirstOrDefaultAsync(x => x.Id == command.Id, cancellationToken);

            _storage.Users.Remove(user);

            await _storage.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
