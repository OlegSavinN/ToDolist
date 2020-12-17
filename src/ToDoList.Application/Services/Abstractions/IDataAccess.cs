using System;
using System.Threading.Tasks;
using ToDoList.Core;

namespace ToDoList.Application.Services.Abstractions
{
    public interface IDataAccess
    {
        Task<User> GetUser(string login, string password);
        Task AddUser(User user);
        Task UpdateUser(User user);
        Task RemoveUser(User user);

        Task<ToDoItemsList[]> GetTodoLists(Guid userId);
        Task AddToDoList(ToDoItemsList list);
        Task UpdateToDoList(ToDoItemsList list);
        Task RemoveToDoList(ToDoItemsList list);

        Task AddToDoItem(ToDoItem toDoItem);
        Task UpdateToDoItem(ToDoItem toDoItem);
        Task RemoveToDoItem(ToDoItem toDoItem);
    }
}
