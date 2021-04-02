using MediatR;
using Microsoft.EntityFrameworkCore;
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
            var user = await _storage.Users
            .Include(x => x.ToDoLists)
            .ThenInclude(x => x.Items)
            .FirstOrDefaultAsync(
                x => x.Id == command.UserId,
                cancellationToken);

            user.UpdateItem(command.ListId, command.Id, command.Title, command.Description, command.Priority, command.State);
            _storage.Users.Update(user);

            await _storage.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
