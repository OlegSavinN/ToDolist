using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ToDoList.Infrastructure.Persistence.Contexts;

namespace ToDoList.Application.Queries.AddUser
{
    public class AddUserCommandHandler : IRequestHandler<AddUserCommand>
    {
        private readonly DatabaseContext _storage;

        public AddUserCommandHandler(
            DatabaseContext storage)
        {
            _storage = storage;
        }

        public async Task<Unit> Handle(
            AddUserCommand command, 
            CancellationToken cancellationToken)
        {
            await _storage.Users.AddAsync(command.User);
            await _storage.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
