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

        public void Update(string login, string birthDate, string name, string email, string role)
        {
            Login = login;
            BirthDate = DateTime.Parse(birthDate);
            Name = name;
            Email = email;
            Role = (Role)Enum.Parse(typeof(Role), role);
        }
        public void RenameList(
            Guid listId,
            string name)
        {
            var list = ToDoLists.FirstOrDefault(x => x.Id == listId);
            list.Rename(name);
        }

        public void DeleteList(Guid listId)
        {
            var list = ToDoLists.FirstOrDefault(x => x.Id == listId);
            ToDoLists.Remove(list);
        }

        public void AddItem(
            Guid listId,
            string title,
            string description,
            string priority,
            string state)
        {
            var list = ToDoLists.FirstOrDefault(x => x.Id == listId);
            var item = new ToDoItem();
            item.Create(listId, title, description, priority, state);
            list.Items.Add(item);
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
