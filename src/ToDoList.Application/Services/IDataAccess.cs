using System;
using System.Threading.Tasks;
using ToDoList.Core.Entities;

namespace ToDoList.Application.Services
{
    public interface IDataAccess
    {
        Task<User> GetUser(string login, string password);
        Task AddUser(User user);
        Task UpdateUser(User user);
        Task RemoveUser(Guid userId);

        Task<ToDoItemsList[]> GetTodoLists(Guid userId);
        Task AddToDoList(ToDoItemsList list);
        Task UpdateToDoList(ToDoItemsList list);
        Task RemoveToDoList(Guid listId);

        Task<ToDoItem[]> GetTodoItem(Guid userId);
        Task AddToDoItem(ToDoItem toDoItem);
        Task UpdateToDoItem(ToDoItem toDoItem);
        Task RemoveToDoItem(Guid toDoItemId);
    }

    public class DataAccess : IDataAccess
    {
        public Task AddToDoItem(ToDoItem toDoItem)
        {
            throw new NotImplementedException();
        }

        public Task AddToDoList(ToDoItemsList list)
        {
            throw new NotImplementedException();
        }

        public Task AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public Task<ToDoItem[]> GetTodoItem(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<ToDoItemsList[]> GetTodoLists(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUser(string login, string password)
        {
            throw new NotImplementedException();
        }

        public Task RemoveToDoItem(Guid toDoItemId)
        {
            throw new NotImplementedException();
        }

        public Task RemoveToDoList(Guid listId)
        {
            throw new NotImplementedException();
        }

        public Task RemoveUser(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateToDoItem(ToDoItem toDoItem)
        {
            throw new NotImplementedException();
        }

        public Task UpdateToDoList(ToDoItemsList list)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
