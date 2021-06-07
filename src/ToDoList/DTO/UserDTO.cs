using System;

namespace ToDoList.DTO
{
    public class UserDTO : IUserId
    {
        public Guid UserId { get; set; }

        public string Login { get; set; }
        public string Password { get; set; }

        public string BirthDate { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}
