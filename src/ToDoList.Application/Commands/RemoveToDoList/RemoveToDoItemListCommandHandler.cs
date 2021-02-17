using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ToDoList.Application.Services;

namespace ToDoList.Application.Queries.RemoveToDoList
{
    class RemoveToDoItemListCommandHandler : IRequestHandler<RemoveToDoItemListCommand>
    {
        private readonly IDataAccess _dataAccess;

        public RemoveToDoItemListCommandHandler(
            IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task<Unit> Handle(
            RemoveToDoItemListCommand command,
            CancellationToken cancellationToken)
        {
            await _dataAccess.RemoveToDoList(command.ListGuid);
            return Unit.Value;
        }
    }
}
