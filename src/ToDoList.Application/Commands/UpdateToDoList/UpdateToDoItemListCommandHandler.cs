using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
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
           var user = await _storage.Users
                .Include(x => x.ToDoLists)
                .ThenInclude(x => x.Items)
                .FirstOrDefaultAsync(
                x => x.Id == command.UserId,
                cancellationToken);

            user.RenameList(command.Id, command.Name);
            _storage.Update(user);

            await _storage.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
