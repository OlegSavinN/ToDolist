using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ToDoList.Infrastructure.Persistence.Contexts;

namespace ToDoList.Application.Queries.RemoveToDoList
{
    class RemoveToDoItemListCommandHandler : IRequestHandler<RemoveToDoItemListCommand>
    {
        private readonly DatabaseContext _storage;

        public RemoveToDoItemListCommandHandler(
            DatabaseContext storage)
        {
            _storage = storage;
        }

        public async Task<Unit> Handle(
            RemoveToDoItemListCommand command,
            CancellationToken cancellationToken)
        {
            _storage.Remove(command.List);
            await _storage.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
