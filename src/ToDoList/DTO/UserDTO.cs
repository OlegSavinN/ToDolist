using System;

namespace ToDoList.DTO
{
    public class UserDTO
    {
        public Guid Id { get; set; }

        public string Login { get; set; }

        public DateTime BirthDate { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }

        public ToDoItemsListDTO[] ToDoLists { get; set; }
    }
}
