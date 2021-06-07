using ToDoList.Core.Exceptions;
using ToDoList.Core.Models;

namespace ToDoList.Core.Validation
{
    internal static class ToDoItemValidator
    {
        public static void Validate(this ToDoItemModel toDoItem)
        {
            if(string.IsNullOrEmpty(toDoItem.Title))
            {
                throw new ValidationException("Title is null");
            }
        }
    }
}
