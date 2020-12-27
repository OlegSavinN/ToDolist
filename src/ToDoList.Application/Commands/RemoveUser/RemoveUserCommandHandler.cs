using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ToDoList.Application.Services;

namespace ToDoList.Application.Commands.RemoveUser
{
    class RemoveUserCommandHandler : IRequestHandler<RemoveUserCommand>
    {
        private readonly IDataAccess _dataAccess;

        public RemoveUserCommandHandler(
            IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task<Unit> Handle(
            RemoveUserCommand command,
            CancellationToken cancellationToken)
        {
            await _dataAccess.RemoveUser(command.UserId);
            return Unit.Value;
        }
    }
}
