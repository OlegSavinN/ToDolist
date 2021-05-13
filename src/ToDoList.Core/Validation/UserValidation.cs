using System.ComponentModel.DataAnnotations;
using ToDoList.Core.Models;

namespace ToDoList.Core.Validation
{
    internal static class UserValidation
    {
        public static void Validate(this UserModel userModel)
        {
            if (string.IsNullOrEmpty(userModel.Login))
            {
                throw new ValidationException("Invalid login");
            }

            if (string.IsNullOrEmpty(userModel.Password))
            {
                throw new ValidationException("Invalid password");
            }

            if (string.IsNullOrEmpty(userModel.Email))
            {
                throw new ValidationException("Invalid email");
            }
            
            //if(string.IsNullOrEmpty(userModel.Role.ToString))
        }
    }
}
