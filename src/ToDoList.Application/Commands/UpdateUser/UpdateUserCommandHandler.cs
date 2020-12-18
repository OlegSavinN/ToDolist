using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ToDoList.Application.Services;

namespace ToDoList.Application.Commands.UpdateUser
{
    class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly IDataAccess _dataAccess;

        public UpdateUserCommandHandler(
            IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task<Unit> Handle(
            UpdateUserCommand command, 
            CancellationToken cancellationToken)
        {
            await _dataAccess.UpdateUser(command.User);
            return Unit.Value;
        }
    }
}
