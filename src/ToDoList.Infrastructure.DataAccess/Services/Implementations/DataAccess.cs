//using System;
//using System.Collections.Generic;
//using System.Data.SqlClient;
//using System.Threading.Tasks;
//using ToDoList.Application.Services;
//using ToDoList.Core;

//namespace ToDoList.Infrastructure.Persistence.Services.Implementations
//{
//    public class DataAccess : IDataAccess
//    {
//        private readonly string _connectionString;

//        public DataAccess(
//            IConnectionStringProvider connectionStringProvider)
//        {
//            _connectionString = connectionStringProvider.GetConnectionString();
//        }

//        public async Task<User> GetUser(string login, string password)
//        {
//            var sql = @"
//                select * from ""Users""
//                where
//                    ""Login"" = @login 
//                and
//                    ""Password"" = @password";

//            User user = await ExecReader<User>(sql, DatabaseMapping.User, command =>
//            {
//                command.Parameters.AddWithValue("login", login);
//                command.Parameters.AddWithValue("password", password);
//            });
//            return user;
//        }

//        public async Task AddUser(User user)
//        {
//            var sql = @"
//                insert into ""Users"" ( 
//                    ""Login"", 
//                    ""Password"", 
//                    ""BirthDate"", 
//                    ""Name"", 
//                    ""Email"",
//                    ""Role"")
//                values ( @login, @password, @birthDate, @name, @email, @role )";

//            await Exec(sql, command =>
//            {
//                command.Parameters.AddWithValue("login", user.Login);
//                command.Parameters.AddWithValue("password", user.Password);
//                command.Parameters.AddWithValue("birthDate", user.BirthDate);
//                command.Parameters.AddWithValue("name", user.Name);
//                command.Parameters.AddWithValue("email", user.Email);
//                command.Parameters.AddWithValue("role", Convert.ToString(user.Role));
//            });
//        }

//        public async Task UpdateUser(User user)
//        {
//            var sql = @"
//                update ""Users"" 
//                set 
//                    ""Login"" = @login, 
//                    ""Password"" = @password, 
//                    ""BirthDate"" = @birthDate, 
//                    ""Name"" = @name, 
//                    ""Email"" = @email
//                    ""Role"" = @role
//                where 
//                    ""Id"" = @id";

//            await Exec(sql, command =>
//            {
//                command.Parameters.AddWithValue("login", user.Login);
//                command.Parameters.AddWithValue("password", user.Password);
//                command.Parameters.AddWithValue("birthDate", user.BirthDate);
//                command.Parameters.AddWithValue("name", user.Name);
//                command.Parameters.AddWithValue("email", user.Email);
//                command.Parameters.AddWithValue("id", user.Id);
//                command.Parameters.AddWithValue("role", Convert.ToString(user.Role));
//            });
//        }

//        public async Task RemoveUser(Guid userId)
//        {
//            var sql = @"
//                    delete from ""Users""
//                    where ""Id"" = @id";

//            await Exec(sql, command =>
//            {
//                command.Parameters.AddWithValue("id", userId);
//            });
//        }

//        public async Task<ToDoItemsList[]> GetTodoLists(Guid userId)
//        {
//            var sql = @"
//                select* from ""ToDoItemLists""
//                where
//                    ""UserId"" = @userId";
//            ToDoItemsList[] toDoItemsLists = await ExecTable<ToDoItemsList>(sql, DatabaseMapping.ToDoItemsList, command =>
//            {
//                command.Parameters.AddWithValue("userId", userId);
//            });
//            return toDoItemsLists;
//        }

//        public async Task AddToDoList(ToDoItemsList list)
//        {
//            var sql = @"
//                insert into ""ToDoItemLists"" (
//                    ""UserId"",
//                    ""Created"",
//                    ""Name"")
//                values ( @userId, @created, @name)";

//            await Exec(sql, command =>
//            {
//                command.Parameters.AddWithValue("userId", list.UserId);
//                command.Parameters.AddWithValue("created", list.Created);
//                command.Parameters.AddWithValue("name", list.Name);
//            });
//        }

//        public async Task UpdateToDoList(ToDoItemsList list)
//        {
//            var sql = @"
//                update ""ToDoItemLists""
//                set
//                    ""Created"" = @created,
//                    ""Name"" = @name
//                where 
//                    ""Id"" = @id";

//            await Exec(sql, command =>
//            {
//                command.Parameters.AddWithValue("created", list.Created);
//                command.Parameters.AddWithValue("name", list.Name);
//                command.Parameters.AddWithValue("id", list.Id);
//            });
//        }

//        public async Task RemoveToDoList(Guid listId)
//        {
//            var sql = @"
//                delete from ""ToDoItemLists""
//                where  
//                    ""Id"" = @id";
//            await Exec(sql, command =>
//            {
//                command.Parameters.AddWithValue("id", listId);
//            });
//        }
//        public async Task<ToDoItem[]> GetTodoItem(Guid listId)
//        {
//            var sql = @"
//                select* from ""ToDoItems""
//                where
//                    ""ListId"" = @listId";

//            ToDoItem[] toDoItem = await ExecTable<ToDoItem>(sql, DatabaseMapping.ToDoItem, command =>
//            {
//                command.Parameters.AddWithValue("listId", listId);
//            });

//            return toDoItem;
//        }

//        public async Task AddToDoItem(ToDoItem toDoItem)
//        {
//            var sql = @"
//                insert into ""ToDoItems"" (
//                    ""ListId"",
//                    ""Date"",
//                    ""Title"",
//                    ""Description"",
//                    ""Priority"",
//                    ""State"")
//                values ( @listId, @date, @title, @description, @priority, @state)";

//            await Exec(sql, command =>
//            {
//                command.Parameters.AddWithValue("listId", toDoItem.ListId);
//                command.Parameters.AddWithValue("date", toDoItem.Date);
//                command.Parameters.AddWithValue("title", toDoItem.Title);
//                command.Parameters.AddWithValue("description", toDoItem.Description);
//                command.Parameters.AddWithValue("priority", Convert.ToString(toDoItem.Priority));
//                command.Parameters.AddWithValue("state", Convert.ToString(toDoItem.State));
//            });
//        }

//        public async Task UpdateToDoItem(ToDoItem toDoItem)
//        {
//            var sql = @"
//                update ""ToDoItems""
//                set
//                    ""ListId"" = @listId,
//                    ""Date"" = @date,
//                    ""Title"" = @title,
//                    ""Description"" = @description,
//                    ""Priority"" = @priority,
//                    ""State"" = @state
//                where
//                    ""Id"" = @id";
//            await Exec(sql, command =>
//            {
//                command.Parameters.AddWithValue("listId", toDoItem.ListId);
//                command.Parameters.AddWithValue("date", toDoItem.Date);
//                command.Parameters.AddWithValue("title", toDoItem.Title);
//                command.Parameters.AddWithValue("description", toDoItem.Description);
//                command.Parameters.AddWithValue("priority", Convert.ToString(toDoItem.Priority));
//                command.Parameters.AddWithValue("state", Convert.ToString(toDoItem.State));
//                command.Parameters.AddWithValue("Id", toDoItem.Id);
//            });
//        }

//        public async Task RemoveToDoItem(Guid toDoItemId)
//        {
//            var sql = @"
//                delete from ""ToDoItems""
//                where
//                    ""Id"" = @id";

//            await Exec(sql, command =>
//           {
//               command.Parameters.AddWithValue("id", toDoItemId);
//           });
//        }

//        private async Task Exec(string sql, Action<SqlCommand> addParamsTo)
//        {
//            await using var conn = new SqlConnection(_connectionString);
//            await conn.OpenAsync();

//            await using var cmd = new SqlCommand(sql, conn);
//            addParamsTo(cmd);

//            await cmd.ExecuteNonQueryAsync();
//        }

//        private async Task<TResult> ExecReader<TResult>(
//            string sql,
//            Func<SqlDataReader, TResult> createInstance,
//            Action<SqlCommand> addParamsTo
//            ) where TResult : class, new()
//        {
//            await using var conn = new SqlConnection(_connectionString);
//            await conn.OpenAsync();

//            await using var cmd = new SqlCommand(sql, conn);
//            addParamsTo(cmd);

//            SqlDataReader reader = await cmd.ExecuteReaderAsync();

//            if (reader.Read())
//            {
//                TResult result = createInstance(reader);
//                return result;
//            }
//            else
//            {
//                return null;
//            }

//        }

//        private async Task<TResult[]> ExecTable<TResult>(
//            string sql,
//            Func<SqlDataReader, TResult> createInstance,
//            Action<SqlCommand> addParamsTo) where TResult : class, new()
//        {
//            await using var conn = new SqlConnection(_connectionString);
//            await conn.OpenAsync();

//            await using var cmd = new SqlCommand(sql, conn);
//            addParamsTo(cmd);

//            SqlDataReader reader = await cmd.ExecuteReaderAsync();

//            List<TResult> result = new List<TResult>();

//            while (reader.Read())
//            {
//                TResult a = createInstance(reader);
//                result.Add(a);
//            }

//            return result.ToArray();
//        }


//    }
//}
