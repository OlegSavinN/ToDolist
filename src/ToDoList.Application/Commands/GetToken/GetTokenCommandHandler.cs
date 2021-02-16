using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using ToDoList.Application.Services;
using ToDoList.Core;

namespace ToDoList.Application.Commands.GetToken
{
    class GetTokenCommandHandler : IRequestHandler<GetTokenCommand>
    {
        private readonly IDataAccess _dataAccess;

        public GetTokenCommandHandler(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        public Task<Unit> Handle(
            GetTokenCommand command,
            CancellationToken cancellationToken)
        {
            User user = _dataAccess.GetUser(command.UserLogin, command.UserPassword);

            return Unit.Value;
        }
    }
}
