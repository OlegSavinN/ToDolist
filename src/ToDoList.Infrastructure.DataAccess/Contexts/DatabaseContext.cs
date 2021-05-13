using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ToDoList.Core.Entities;
using ToDoList.Infrastructure.Persistence.Configurations;
using ToDoList.Infrastructure.Persistence.Options;

namespace ToDoList.Infrastructure.Persistence.Contexts
{
    public class DatabaseContext : DbContext
    {
        private const string DefaultConnectionString = "Host=localhost; Port=5432; Database=ToDoListDB; Username=postgres; Password=postgres";
        private readonly DatabaseContextOptions _options;

        public DbSet<User> Users { get; set; }

        public DatabaseContext()
        {
        }

        public DatabaseContext(
            IOptions<DatabaseContextOptions> options)
        {
            _options = options.Value;
        }

        protected override void OnModelCreating(
            ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfiguration(new UserConfiguration())
                .ApplyConfiguration(new ToDoItemsListConfiguration())
                .ApplyConfiguration(new ToDoItemConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                ////.UseLoggerFactory(LogFactory)
                .UseNpgsql(_options?.ConnectionString ?? DefaultConnectionString);

            base.OnConfiguring(optionsBuilder);
        }
    }
}
