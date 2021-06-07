using System;
using ToDoList.Core.Models;
using ToDoList.Core.Validation;

namespace ToDoList.Core.Entities
{
    public class ToDoItem
    {
        public Guid Id { get; private set; }
        public Guid ListId { get; private set; }

        public DateTime CreatedDate { get; private set; }
        public DateTime LastModifiedDate { get; private set; }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public Priority Priority { get; private set; }
        public State State { get; private set; }

        private ToDoItem()
        {
            Id = Guid.NewGuid();
            CreatedDate = DateTime.UtcNow;
        }

        internal ToDoItem(
            Guid listId,
            ToDoItemModel todoItemModel): this()
        {
            ListId = listId;

            Update(todoItemModel);
        }

        public void Update (ToDoItemModel todoItemModel)
        {
            todoItemModel.Validate();

            LastModifiedDate = DateTime.UtcNow;

            Title = todoItemModel.Title;
            Description = todoItemModel.Description;
            Priority = todoItemModel.Priority;
            State = todoItemModel.State;
        }
    }
}
