using System;
using System.Collections.Generic;
using System.Linq;
using ToDoList.Core.Models;
using ToDoList.Core.Validation;

namespace ToDoList.Core.Entities
{
    public class User
    {
        public Guid Id { get; private set; }
        
        public string Login { get; private set; }
        public string Password { get; private set; }

        public DateTime BirthDate { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public Role Role { get; private set; }

        public List<ToDoItemsList> ToDoLists { get; set; }

        private User()
        {
            Id = Guid.NewGuid();
        }

        public User(UserModel usermodel) :this()
        {
            Update(usermodel);
        }

        public void Update(UserModel usermodel)
        {
            usermodel.Validate();

            Login = usermodel.Login;
            Password = usermodel.Password;

            BirthDate = usermodel.BirthDate;
            Name = usermodel.Name;
            Email = usermodel.Email;
            Role = usermodel.Role;
        }

        public void RenameList(
            Guid listId,
            string name)
        {
            var list = ToDoLists.FirstOrDefault(x => x.Id == listId);
            list.Update(name);
        }

        public void DeleteList(Guid listId)
        {
            var list = ToDoLists.FirstOrDefault(x => x.Id == listId);
            ToDoLists.Remove(list);
        }

        public void AddItem(
            Guid listId,
            ToDoItemModel toDoItemModel)
        {
            var list = ToDoLists.FirstOrDefault(x => x.Id == listId);
            list.AddItem(toDoItemModel);
        }
         
        public void UpdateItem(
            Guid listId,
            Guid itemId,
            ToDoItemModel toDoItemModel)
        {
            var list = ToDoLists.FirstOrDefault(x => x.Id == listId);
            var item = list.Items.FirstOrDefault(x => x.Id == itemId);

            item.Update(toDoItemModel);
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
