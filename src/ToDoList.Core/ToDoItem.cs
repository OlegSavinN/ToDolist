using System;

namespace ToDoList.Core
{
    public class ToDoItem
    {
        public Guid Id { get; set; }
        public Guid ListId { get; set; }

        public DateTime Date { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public Priority Priority { get; set; }
        public State State { get; set; }
    }
}
