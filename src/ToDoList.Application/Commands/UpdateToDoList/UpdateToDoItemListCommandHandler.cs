using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ToDoList.Application.Services;

namespace ToDoList.Application.Commands.UpdateToDoList
{
    class UpdateToDoItemListCommandHandler : IRequestHandler<UpdateToDoItemListCommand>
    {
        private readonly IDataAccess _dataAccess;

        public UpdateToDoItemListCommandHandler(
            IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        public async Task<Unit> Handle(
            UpdateToDoItemListCommand command,
            CancellationToken cancellationToken)
        {
            await _dataAccess.UpdateToDoList(command.ToDoItemsList);
            return Unit.Value;
        }
    }
}
