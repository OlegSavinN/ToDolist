using System;
using ToDoList.Core.Entities;

namespace ToDoList.Core.Models
{
    public class UserModel
    {
        public string Login { get; private set; }
        public string Password { get; private set; }

        public DateTime BirthDate { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public Role Role { get; private set; }
    }
}
