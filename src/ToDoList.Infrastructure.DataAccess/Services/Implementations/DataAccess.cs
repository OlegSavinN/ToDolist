using System;
using System.Threading.Tasks;
using Npgsql;
using ToDoList.Application.Services;
using ToDoList.Core;

namespace ToDoList.Infrastructure.Persistence.Services.Implementations
{
    public class DataAccess : IDataAccess
    {
        private readonly string _connectionString;

        public DataAccess(
            IConnectionStringProvider connectionStringProvider)
        {
            _connectionString = connectionStringProvider.GetConnectionString();
        }

        public Task<User> GetUser(string login, string password)
        {
            throw new NotImplementedException();
        }

        public async Task AddUser(User user)
        {
            var sql = @"
                insert into ""Users"" ( 
                    ""Login"", 
                    ""Password"", 
                    ""BirthDate"", 
                    ""Name"", 
                    ""Email"")
                values ( @login, @password, @birthDate, @name, @email )";

            await Exec(sql, command =>
            {
                command.Parameters.AddWithValue("login", user.Login);
                command.Parameters.AddWithValue("password", user.Password);
                command.Parameters.AddWithValue("birthDate", user.BirthDate);
                command.Parameters.AddWithValue("name", user.Name);
                command.Parameters.AddWithValue("email", user.Email);
            });
        }

        public async Task UpdateUser(User user)
        {
            var sql = @"
                update ""Users"" 
                set 
                    ""Login"" = @login, 
                    ""Password"" = @password, 
                    ""BirthDate"" = @birthDate, 
                    ""Name"" = @name, 
                    ""Email"" = @email
                where 
                    ""Id"" = @id";

            await Exec(sql, command =>
            {
                command.Parameters.AddWithValue("login", user.Login);
                command.Parameters.AddWithValue("password", user.Password);
                command.Parameters.AddWithValue("birthDate", user.BirthDate);
                command.Parameters.AddWithValue("name", user.Name);
                command.Parameters.AddWithValue("email", user.Email);
                command.Parameters.AddWithValue("id", user.Id);
            });
        }

        public Task RemoveUser(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<ToDoItemsList[]> GetTodoLists(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task AddToDoList(ToDoItemsList list)
        {
            throw new NotImplementedException();
        }

        public Task UpdateToDoList(ToDoItemsList list)
        {
            throw new NotImplementedException();
        }

        public Task RemoveToDoList(ToDoItemsList list)
        {
            throw new NotImplementedException();
        }

        public Task AddToDoItem(ToDoItem toDoItem)
        {
            throw new NotImplementedException();
        }

        public Task UpdateToDoItem(ToDoItem toDoItem)
        {
            throw new NotImplementedException();
        }

        public Task RemoveToDoItem(ToDoItem toDoItem)
        {
            throw new NotImplementedException();
        }

        private async Task Exec(string sql, Action<NpgsqlCommand> addParamsTo)
        {
            await using var conn = new NpgsqlConnection(_connectionString);
            await conn.OpenAsync();

            await using var cmd = new NpgsqlCommand(sql, conn);
            addParamsTo(cmd);

            await cmd.ExecuteNonQueryAsync();
        }
    }
}
