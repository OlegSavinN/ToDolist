using System;

namespace ToDoList.DTO
{
    public class ToDoItemsListDTO
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }

        public string Name { get; set; }
    }
}
