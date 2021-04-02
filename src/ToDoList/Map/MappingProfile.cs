using AutoMapper;
using ToDoList.Application.Queries.AddToDoItem;
using ToDoList.Application.Queries.AddToDoList;
using ToDoList.Application.Queries.GetToken;
using ToDoList.Application.Queries.GetUser;
using ToDoList.Application.Queries.RemoveToDoItem;
using ToDoList.Application.Queries.RemoveToDoList;
using ToDoList.Application.Queries.UpdateToDoItem;
using ToDoList.Application.Queries.UpdateToDoList;
using ToDoList.Application.Queries.UpdateUser;
using ToDoList.Core;
using ToDoList.DTO;

namespace ToDoList.Map
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, GetUserQuery>();
            CreateMap<UserDTO, UpdateUserCommand>();
            CreateMap<AuthRequestDTO, GetTokenQuery>();
            CreateMap<ToDoItemDTO, UpdateToDoItemCommand>();
            CreateMap<ToDoItemDTO, RemoveToDoItemCommand>();
            CreateMap<ToDoItemDTO, AddToDoItemCommand>();
            CreateMap<ToDoItemsListDTO, AddToDoItemListCommand>();
            CreateMap<ToDoItemsListDTO, RemoveToDoItemListCommand>();
            CreateMap<ToDoItemsListDTO, UpdateToDoItemListCommand>();
        }
    }
}
