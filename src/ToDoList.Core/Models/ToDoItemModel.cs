using ToDoList.Core.Entities;

namespace ToDoList.Core.Models
{
    public class ToDoItemModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Priority Priority { get; set; }
        public State State { get; set; }
    }
}
