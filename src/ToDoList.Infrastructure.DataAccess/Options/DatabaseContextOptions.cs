namespace ToDoList.Infrastructure.Persistence.Options
{
    public class DatabaseContextOptions
    {
        public string ConnectionString { get; set; }
        public bool LogSql { get; set; }
        public object Value { get; internal set; }
    }
}
