using System;
using System.Collections.Generic;
using System.Linq;

namespace ToDoList.Core
{
    public class User
    {
        public Guid Id { get; set; }
        
        public string Login { get; set; }
        public string Password { get; set; }

        public DateTime BirthDate { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }

        public List<ToDoItemsList> ToDoLists { get; set; }

        public void RenameList(
            Guid listId,
            string name)
        {
            var list = ToDoLists.FirstOrDefault(x => x.Id == listId);
            list.Rename(name);
        }

        public void UpdateItem(
            Guid listId,
            Guid itemId,
            string title,
            string description,
            string priority,
            string state)
        {
            var list = ToDoLists.FirstOrDefault(x => x.Id == listId);
            var item = list.Items.FirstOrDefault(x => x.Id == itemId);

            item.Update(
                title, 
                description,
                priority,
                state);
        }

        public void DeleteItem(
            Guid listId,
            Guid itemId)
        {
            var list = ToDoLists.FirstOrDefault(x => x.Id == listId);
            list.DeleteItem(itemId);
        }
    }
}
