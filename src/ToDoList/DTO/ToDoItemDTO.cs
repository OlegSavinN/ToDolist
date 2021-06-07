using System;

namespace ToDoList.DTO
{
    public class ToDoItemDTO : IUserId
    {
        public Guid Id { get; set; }
        public Guid ListId { get; set; }
        public Guid UserId { get; set; }

        public DateTime Date { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public string Priority { get; set; }
        public string State { get; set; }
    }
}
