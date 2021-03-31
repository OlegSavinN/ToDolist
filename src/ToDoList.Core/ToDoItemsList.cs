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

        public void AddItem(
            ToDoItem item)
        {
            Items.Add(item);
        }

        public void DeleteItem(
            Guid toDoItem)
        {
            var item = Items.FirstOrDefault(x => x.Id == toDoItem);
            Items.Remove(item);
        }
    }
}
