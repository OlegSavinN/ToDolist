using System;
using System.Collections.Generic;
using System.Linq;

namespace ToDoList.Core
{
    public class ToDoItemsList
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }

        public DateTime Created { get; set; }

        public string Name { get; set; }
        public List<ToDoItem> Items { get; set; }

        public void Rename(string name)
        {
            Name = name;
        }

        public void Create(Guid userid, string name)
        {
            Id = Guid.NewGuid();
            UserId = userid;
            Created = DateTime.Now;
            Name = name;
        }

        public void DeleteItem(
            Guid toDoItem)
        {
            var item = Items.FirstOrDefault(x => x.Id == toDoItem);
            Items.Remove(item);
        }
    }
}
