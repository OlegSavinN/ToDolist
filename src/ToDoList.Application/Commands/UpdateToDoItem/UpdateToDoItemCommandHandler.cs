using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ToDoList.Application.Services;

namespace ToDoList.Application.Commands.UpdateToDoItem
{
    class UpdateToDoItemCommandHandler : IRequestHandler<UpdateToDoItemCommand>
    {
        private readonly IDataAccess _dataAccess;

        public UpdateToDoItemCommandHandler(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        public async Task<Unit> Handle(
            UpdateToDoItemCommand command,
            CancellationToken cancellationToken)
        {
            await _dataAccess.UpdateToDoItem(command.ToDoItem);
            return Unit.Value;
        }
    }
}
