﻿using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDoList.Infrastructure.Persistence.Contexts;

namespace ToDoList.Application.Queries.UpdateUser
{
    class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly DatabaseContext _storage;

        public UpdateUserCommandHandler(
            DatabaseContext storage)
        {
            _storage = storage;
        }

        public async Task<Unit> Handle(
            UpdateUserCommand command, 
            CancellationToken cancellationToken)
        {
            var user = await _storage.Users
                .FirstOrDefaultAsync(x => x.Id == command.Id, cancellationToken);

            user.Update(command.Login, command.BirthDate, command.Name, command.Email, command.Role);

            _storage.Users.Update(user);
            await _storage.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
