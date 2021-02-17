using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ToDoList.Application.Services;
using ToDoList.Core;

namespace ToDoList.Application.Queries.GetToDoList
{
    class GetToDoItemListQueryHandler : IRequestHandler<GetToDoItemListQuery, ToDoItemsList[]>
    {
        private readonly IDataAccess _dataAccess;

        public GetToDoItemListQueryHandler(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        public async Task<ToDoItemsList[]> Handle(
            GetToDoItemListQuery query, 
            CancellationToken cancellationToken)
        {
            ToDoItemsList[] todoitem = await _dataAccess.GetTodoLists(query.UserId);
            return todoitem;
        }
    }
}
