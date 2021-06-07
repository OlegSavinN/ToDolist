using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ToDoList.Core.Entities;
using ToDoList.Infrastructure.Persistence.Contexts;

namespace ToDoList.Application.Queries.GetToDoItem
{
    class GetToDoItemQueryHandler : IRequestHandler<GetToDoItemQuery, List<ToDoItem>>
    {
        private readonly DatabaseContext _storage;

        public GetToDoItemQueryHandler(DatabaseContext storage)
        {
            _storage = storage;
        }

        public async Task<List<ToDoItem>> Handle(
            GetToDoItemQuery query,
            CancellationToken cancellationToken)
        {
            User user = await _storage.Users
                .Include(x => x.ToDoLists)
                .ThenInclude(x => x.Items)
                .FirstOrDefaultAsync(x => x.Id == query.UserId, cancellationToken);

            var toDoItemsList = user.ToDoLists;
            List<ToDoItem> toDoItems = new List<ToDoItem>();

            foreach (ToDoItemsList list in toDoItemsList)
            {
                foreach (ToDoItem item in list.Items)
                {
                    toDoItems.Add(item);
                }
            }
            return toDoItems;
        }
    }
}
