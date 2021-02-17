using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ToDoList.Application.Services;
using ToDoList.Core;

namespace ToDoList.Application.Queries.GetToDoItem
{
    class GetToDoItemQueryHandler : IRequestHandler<GetToDoItemQuery, ToDoItem[]>
    {
        private readonly IDataAccess _dataAccess;
        public GetToDoItemQueryHandler(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        public async Task<ToDoItem[]> Handle(
            GetToDoItemQuery command,
            CancellationToken cancellationToken)
        {
            ToDoItem[] todoItem = await _dataAccess.GetTodoItem(command.ListId);
            return todoItem;
        }
    }
}
