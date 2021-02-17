using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ToDoList.Application.Services;

namespace ToDoList.Application.Queries.AddToDoItem
{
    class AddToDoItemCommandHandler : IRequestHandler<AddToDoItemCommand>
    {
        private readonly IDataAccess _dataAccess;

        public AddToDoItemCommandHandler(
            IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        public async Task<Unit> Handle(
            AddToDoItemCommand command,
            CancellationToken cancellationToken)
        {
            await _dataAccess.AddToDoItem(command.ToDoItem);
            return Unit.Value;
        }
    }
}
