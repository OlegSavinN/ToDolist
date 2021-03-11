using Microsoft.EntityFrameworkCore;
using System.Linq;
using ToDoList.Infrastructure.Persistence.Contexts;

namespace ToDoList.Infrastructure.Persistence.Extentions
{
    public static class DatabaseContextExtentions
    {
        public static DatabaseContext Migrate (
            this DatabaseContext databaseContext)
        {
            var migrations = databaseContext.Database.GetPendingMigrations().ToArray();
            System.Console.WriteLine(string.Join(", ", migrations));

            databaseContext.Database.Migrate();

            return databaseContext;
        }
    }
}
