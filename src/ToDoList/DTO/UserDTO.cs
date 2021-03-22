using System;
using ToDoList.Core;

namespace ToDoList.DTO
{
    class UserDTO
    {
        public Guid Id { get; set; }

        public string Login { get; set; }

        public DateTime BirthDate { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }

        public ToDoItemsList[] ToDoLists { get; set; }
    }
}
