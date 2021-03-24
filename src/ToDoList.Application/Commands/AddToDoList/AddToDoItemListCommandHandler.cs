using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ToDoList.Infrastructure.Persistence.Contexts;

namespace ToDoList.Application.Queries.AddToDoList
{
    public class AddToDoItemListCommandHandler : IRequestHandler<AddToDoItemListCommand>
    {
        private readonly DatabaseContext _storage;

        public AddToDoItemListCommandHandler(
            DatabaseContext storage)
        {
            _storage = storage;
        }
        public async Task<Unit> Handle(
            AddToDoItemListCommand command,
            CancellationToken cancellationToken)
        {
            _storage.Add(command.ToDoItemsList);
            await _storage.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
