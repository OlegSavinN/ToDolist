using MediatR;
using Microsoft.EntityFrameworkCore;
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
            var user = await _storage.Users
            .Include(x => x.ToDoLists)
            .ThenInclude(x => x.Items)
            .FirstOrDefaultAsync(
                x => x.Id == command.UserId,
                cancellationToken);

            user.DeleteList(command.Id);
            _storage.Users.Update(user);
            await _storage.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
