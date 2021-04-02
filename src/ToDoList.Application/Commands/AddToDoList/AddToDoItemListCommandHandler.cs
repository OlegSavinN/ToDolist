using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ToDoList.Core;
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
            var user = await _storage.Users
                .Include(x => x.ToDoLists)
                .ThenInclude(x => x.Items)
                .FirstOrDefaultAsync(x => x.Id == command.UserId, cancellationToken);
            var list = new ToDoItemsList();
            
            list.Create(command.UserId, command.Name);
            user.ToDoLists.Add(list);
             _storage.Users.Update(user);
            _storage.SaveChanges();

            return Unit.Value;
        }
    }
}
