using MediatR;
using System.Threading;
using System.Threading.Tasks;
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
            _storage.Users.Remove(command.User);
            await _storage.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
