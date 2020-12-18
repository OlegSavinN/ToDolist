namespace ToDoList.Infrastructure.Persistence.Services
{
    public interface IConnectionStringProvider
    {
        string GetConnectionString();
    }
}
