using System;

namespace ToDoList.DTO
{
    public class ToDoItemsListDTO : IUserId  
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }

        public string Name { get; set; }
    }
}
