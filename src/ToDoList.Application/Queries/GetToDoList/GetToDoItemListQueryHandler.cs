using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ToDoList.Core.Entities;
using ToDoList.Infrastructure.Persistence.Contexts;

namespace ToDoList.Application.Queries.GetToDoList
{
    class GetToDoItemListQueryHandler : IRequestHandler<GetToDoItemListQuery, List<ToDoItemsList>>
    {
        private readonly DatabaseContext _storage;

        public GetToDoItemListQueryHandler(DatabaseContext storage)
        {
            _storage = storage;
        }
        public async Task<List<ToDoItemsList>> Handle(
            GetToDoItemListQuery query, 
            CancellationToken cancellationToken)
        {
            var user = await _storage.Users
                .Include(x => x.ToDoLists)
                .ThenInclude(x => x.Items)
                .FirstOrDefaultAsync(x => x.Id == query.UserId, cancellationToken);

            var toDoItemsList = user.ToDoLists;
            
            return toDoItemsList;
        }
    }
}
