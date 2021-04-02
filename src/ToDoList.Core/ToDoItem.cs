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

        public void Create(
            Guid listId,
            string title,
            string description,
            string priority,
            string state)
        {
            Id = Guid.NewGuid();
            ListId = listId;
            Date = DateTime.Now;
            Title = title;
            Description = description;
            Priority = (Priority)Enum.Parse(typeof(Priority), priority);
            State = (State)Enum.Parse(typeof(State), state);
        }

        public void Update (
            string title,
            string description,
            string priority,
            string state)
        {

            Date = DateTime.Now;
            Title = title;
            Description = description;
            Priority = (Priority)Enum.Parse(typeof(Priority), priority);
            State = (State)Enum.Parse(typeof(State), state);
        }
    }
}
