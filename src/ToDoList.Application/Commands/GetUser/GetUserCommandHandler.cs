using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ToDoList.Application.Services;

namespace ToDoList.Application.Commands.GetUser
{
    class GetUserCommandHandler : IRequestHandler<GetUserCommand>
    {
        private readonly IDataAccess _dataAccess;

        public GetUserCommandHandler(
            IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        public async Task<Unit> Handle(
            GetUserCommand command,
            CancellationToken cancellationToken)
        {
            await _dataAccess.GetUser(command.UserLogin, command.UserPassword);
            return Unit.Value;
        }
    }
}
