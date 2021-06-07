using System;
using System.Collections.Generic;
using System.Linq;
using ToDoList.Core.Models;

namespace ToDoList.Core.Entities
{
    public class ToDoItemsList
    {
        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }

        public DateTime CreatedDate { get; private set; }
        public DateTime LastModifiedDate { get; private set; }

        public string Name { get; private set; }
        public List<ToDoItem> Items { get; private set; }

        private ToDoItemsList()
        {
            Id = Guid.NewGuid();
            CreatedDate = DateTime.UtcNow;
        }

        public ToDoItemsList(Guid userId, string name) : this()
        {
            UserId = userId;
            Update(name);
        }

        public void Update(string name)
        {
            Name = name;
            LastModifiedDate = DateTime.UtcNow;
        }

        public void DeleteItem(Guid toDoItem)
        {
            var item = Items.FirstOrDefault(x => x.Id == toDoItem);
            Items.Remove(item);
        }

        public void AddItem(ToDoItemModel toDoItemModel)
        {
            var item = new ToDoItem(Id, toDoItemModel);
            Items.Add(item);
        }
    }
}
