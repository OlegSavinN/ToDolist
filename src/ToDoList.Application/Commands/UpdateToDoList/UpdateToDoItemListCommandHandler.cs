using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ToDoList.Core;
using ToDoList.Infrastructure.Persistence.Contexts;

namespace ToDoList.Application.Queries.UpdateToDoList
{
    class UpdateToDoItemListCommandHandler : IRequestHandler<UpdateToDoItemListCommand>
    {
        private readonly DatabaseContext _storage;

        public UpdateToDoItemListCommandHandler(
            DatabaseContext storage)
        {
            _storage = storage;
        }
        public async Task<Unit> Handle(
            UpdateToDoItemListCommand command,
            CancellationToken cancellationToken)
        {
            _storage.Update(command.ToDoItemsList);
            await _storage.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
