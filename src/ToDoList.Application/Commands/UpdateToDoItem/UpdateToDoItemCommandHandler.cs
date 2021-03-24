using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ToDoList.Infrastructure.Persistence.Contexts;

namespace ToDoList.Application.Queries.UpdateToDoItem
{
    class UpdateToDoItemCommandHandler : IRequestHandler<UpdateToDoItemCommand>
    {
        private readonly DatabaseContext _storage;

        public UpdateToDoItemCommandHandler(DatabaseContext storage)
        {
            _storage = storage;
        }

        public async Task<Unit> Handle(
            UpdateToDoItemCommand command,
            CancellationToken cancellationToken)
        {
            _storage.Update(command.ToDoItem);
            await _storage.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
