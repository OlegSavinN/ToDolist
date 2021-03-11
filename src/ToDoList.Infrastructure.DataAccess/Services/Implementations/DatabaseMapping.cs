using System;
using System.Data.SqlClient;
using ToDoList.Core;

namespace ToDoList.Infrastructure.Persistence.Services.Implementations
{
    internal static class DatabaseMapping
    {
        public static User User (SqlDataReader reader)
        {
            var user = new User();

            user.Id = reader.GetGuid(0);
            user.Login = reader.GetString(1);
            user.Password = reader.GetString(2);
            user.BirthDate = reader.GetDateTime(3);
            user.Name = reader.GetString(4);
            user.Email = reader.GetString(5);
            user.ToDoLists = null;
            user.Role = (Role)Enum.Parse(typeof(Role), reader.GetString(6));

            return user;
        }

        public static ToDoItemsList ToDoItemsList (SqlDataReader reader)
        {
            var toDoItemsList = new ToDoItemsList();

            toDoItemsList.Id = reader.GetGuid(0);
            toDoItemsList.UserId = reader.GetGuid(1);
            toDoItemsList.Created = reader.GetDateTime(2);
            toDoItemsList.Name = reader.GetString(3);
            toDoItemsList.Items = null;

            return toDoItemsList;
        }

        public static ToDoItem ToDoItem (SqlDataReader reader)
        {
            var toDoItem = new ToDoItem();

            toDoItem.Id = reader.GetGuid(0);
            toDoItem.ListId = reader.GetGuid(1);
            toDoItem.Date = reader.GetDateTime(2);
            toDoItem.Title = reader.GetString(3);
            toDoItem.Description = reader.GetString(4);
            toDoItem.Priority = (Priority)Enum.Parse(typeof(Priority), reader.GetString(5));
            toDoItem.State = (State)Enum.Parse(typeof(State), reader.GetString(6));

            return toDoItem;
        }
    }
}
