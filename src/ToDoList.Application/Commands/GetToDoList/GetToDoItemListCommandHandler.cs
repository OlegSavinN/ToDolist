using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ToDoList.Application.Services;

namespace ToDoList.Application.Commands.GetToDoList
{
    class GetToDoItemListCommandHandler : IRequestHandler<GetToDoItemListCommand>
    {
        private readonly IDataAccess _dataAccess;

        public GetToDoItemListCommandHandler(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        public async Task<Unit> Handle(
            GetToDoItemListCommand command, 
            CancellationToken cancellationToken)
        {
            await _dataAccess.GetTodoLists(command.UserId);
            return Unit.Value;
        }
    }
}
