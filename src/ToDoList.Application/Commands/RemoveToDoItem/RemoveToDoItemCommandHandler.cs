using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using ToDoList.Infrastructure.Persistence.Contexts;

namespace ToDoList.Application.Queries.RemoveToDoItem
{
    class RemoveToDoItemCommandHandler : IRequestHandler<RemoveToDoItemCommand>
    {
        private readonly DatabaseContext _storage;

        public RemoveToDoItemCommandHandler(
            DatabaseContext storage)
        {
            _storage = storage;
        }

        public async Task<Unit> Handle(
            RemoveToDoItemCommand command,
            CancellationToken cancellationToken)
        {
            //_storage.Remove(command.ToDoItem);
            //await _storage.SaveChangesAsync();
            var user = await _storage.Users
            .Include(x => x.ToDoLists)
            .ThenInclude(x => x.Items)
            .FirstOrDefaultAsync(
                x => x.Id == command.UserId,
                cancellationToken);

            user.DeleteItem(command.ListId, command.Id);
            _storage.Users.Update(user);
            await _storage.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
