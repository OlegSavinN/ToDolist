using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ToDoList.Application.Services;

namespace ToDoList.Application.Queries.AddToDoList
{
    public class AddToDoItemListCommandHandler : IRequestHandler<AddToDoItemListCommand>
    {
        private readonly IDataAccess _dataAccess;

        public AddToDoItemListCommandHandler(
            IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        public async Task<Unit> Handle(
            AddToDoItemListCommand command,
            CancellationToken cancellationToken)
        {
            await _dataAccess.AddToDoList(command.ToDoItemsList);
            return Unit.Value;
        }
    }
}
