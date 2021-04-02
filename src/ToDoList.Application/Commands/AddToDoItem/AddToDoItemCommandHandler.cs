using MediatR;
using Microsoft.EntityFrameworkCore;
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
            var user = await _storage.Users
            .Include(x => x.ToDoLists)
            .ThenInclude(x =>x.Items)
            .FirstOrDefaultAsync(
                x => x.Id == command.UserId,
                cancellationToken);

            user.AddItem(
                command.ListId,
                command.Title,
                command.Description,
                command.Priority,
                command.State);

            _storage.Update(user);
            await _storage.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
