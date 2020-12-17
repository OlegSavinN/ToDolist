using System;
using System.Threading.Tasks;
using Npgsql;
using ToDoList.Application.Services.Abstractions;
using ToDoList.Core;

namespace ToDoList.Infrastructure.Persistence.Services
{
    public class DataAccess : IDataAccess
    {
        private readonly string _connectionString;

        public DataAccess(string connectionString)
        {
            _connectionString = connectionString;
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

            await using var conn = new NpgsqlConnection(_connectionString);
            await conn.OpenAsync();

            await using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("login", user.Login);
            cmd.Parameters.AddWithValue("password", user.Password);
            cmd.Parameters.AddWithValue("birthDate", user.BirthDate);
            cmd.Parameters.AddWithValue("name", user.Name);
            cmd.Parameters.AddWithValue("email", user.Email);

            await cmd.ExecuteNonQueryAsync();
        }

        public Task UpdateUser(User user)
        {
            throw new NotImplementedException();
        }

        public Task RemoveUser(User user)
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
