using System;
using System.Threading.Tasks;
using ToDoList.Core;

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
}
