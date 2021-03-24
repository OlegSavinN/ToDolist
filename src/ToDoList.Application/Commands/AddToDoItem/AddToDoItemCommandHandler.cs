using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ToDoList.Infrastructure.Persistence.Contexts;

namespace ToDoList.Application.Queries.AddToDoItem
{
    class AddToDoItemCommandHandler : IRequestHandler<AddToDoItemCommand>
    {
        private readonly DatabaseContext _storage;

        public AddToDoItemCommandHandler(
            DatabaseContext storage)
        {
            _storage = storage;
        }

        public async Task<Unit> Handle(
            AddToDoItemCommand command,
            CancellationToken cancellationToken)
        {
            _storage.Add(command.ToDoItem);
            await _storage.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
