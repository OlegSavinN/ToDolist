using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ToDoList.Infrastructure.Persistence.Contexts;

namespace ToDoList.Application.Queries.UpdateUser
{
    class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly DatabaseContext _storage;

        public UpdateUserCommandHandler(
            DatabaseContext storage)
        {
            _storage = storage;
        }

        public async Task<Unit> Handle(
            UpdateUserCommand command, 
            CancellationToken cancellationToken)
        {
            var user = _storage.Users.Update(command.User);
            await _storage.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
