using System;

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

        public ToDoItemsList[] ToDoLists { get; set; }
    }
}
