using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ToDoList.Application.Services.Abstractions;

namespace ToDoList.Application.Commands.AddUser
{
    public class AddUserCommandHandler : IRequestHandler<AddUserCommand>
    {
        private readonly IDataAccess _dataAccess;

        public AddUserCommandHandler(
            IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task<Unit> Handle(
            AddUserCommand command, 
            CancellationToken cancellationToken)
        {
            await _dataAccess.AddUser(command.User);
            return Unit.Value;
        }
    }
}
