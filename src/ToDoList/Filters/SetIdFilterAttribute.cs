using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Threading.Tasks;
using ToDoList.DTO;

namespace ToDoList.Filters
{
    public class SetIdFilterAttribute : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(
            ActionExecutingContext context,
            ActionExecutionDelegate next)
        {
            foreach(var i in context.ActionArguments.Values)
            {
                if(i is IUserId user)
                {
                    string userId = context.HttpContext.User.FindFirst("UserId").Value;
                    user.UserId = Guid.Parse(userId);
                }
            }

            await next();
        }
    }
}
