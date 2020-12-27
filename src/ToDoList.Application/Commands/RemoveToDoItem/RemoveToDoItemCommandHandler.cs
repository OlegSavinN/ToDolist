using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ToDoList.Application.Services;

namespace ToDoList.Application.Commands.RemoveToDoItem
{
    class RemoveToDoItemCommandHandler : IRequestHandler<RemoveToDoItemCommand>
    {
        private readonly IDataAccess _dataAccess;
        public RemoveToDoItemCommandHandler(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        public async Task<Unit> Handle(
            RemoveToDoItemCommand command,
            CancellationToken cancellationToken)
        {
            await _dataAccess.RemoveToDoItem(command.ToDoItemId);
            return Unit.Value;
        }
    }
}
