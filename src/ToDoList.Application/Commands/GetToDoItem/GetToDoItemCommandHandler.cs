using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ToDoList.Application.Services;

namespace ToDoList.Application.Commands.GetToDoItem
{
    class GetToDoItemCommandHandler : IRequestHandler<GetToDoItemCommand>
    {
        private readonly IDataAccess _dataAccess;
        public GetToDoItemCommandHandler(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        public async Task<Unit> Handle(
            GetToDoItemCommand command,
            CancellationToken cancellationToken)
        {
            await _dataAccess.GetTodoItem(command.ListId);
            return Unit.Value;
        }
    }
}
