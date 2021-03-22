using System;
using System.Collections.Generic;

namespace ToDoList.Core
{
    public class ToDoItemsList
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }

        public DateTime Created { get; set; }

        public string Name { get; set; }
        public List<ToDoItem> Items { get; set; }
    }
}
