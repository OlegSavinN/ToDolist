using AutoMapper;
using ToDoList.Application.Queries.AddToDoItem;
using ToDoList.Application.Queries.AddToDoList;
using ToDoList.Application.Queries.AddUser;
using ToDoList.Application.Queries.GetToDoList;
using ToDoList.Application.Queries.GetToken;
using ToDoList.Application.Queries.GetUser;
using ToDoList.Application.Queries.RemoveToDoItem;
using ToDoList.Application.Queries.RemoveToDoList;
using ToDoList.Application.Queries.RemoveUser;
using ToDoList.Application.Queries.UpdateToDoItem;
using ToDoList.Application.Queries.UpdateToDoList;
using ToDoList.Application.Queries.UpdateUser;
using ToDoList.Core.Entities;
using ToDoList.Core.Models;
using ToDoList.DTO;

namespace ToDoList.Map
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, GetUserQuery>();
            CreateMap<UserDTO, UpdateUserCommand>()
                .ForMember(x => x.UserModel, x => x.MapFrom(dto => dto));
            CreateMap<UserDTO, UserModel>();
            CreateMap<UserDTO, AddUserCommand>()
                .ForMember(x => x.UserModel, x => x.MapFrom(dto => dto));
            CreateMap<UserDTO, RemoveUserCommand>()
                .ForMember(x => x.UserModel, x => x.MapFrom(dto => dto));
            CreateMap<AuthRequestDTO, GetTokenQuery>();

            CreateMap<ToDoItem, ToDoItemDTO>();
            CreateMap<ToDoItemDTO, UpdateToDoItemCommand>();
            CreateMap<ToDoItemDTO, RemoveToDoItemCommand>();
            CreateMap<ToDoItemDTO, AddToDoItemCommand>()
                .ForMember(x => x.ToDoItemModel, x => x.MapFrom(dto => dto));
            CreateMap<ToDoItemDTO, ToDoItemModel>();

            CreateMap<ToDoItemsList, ToDoItemsListDTO>();
            CreateMap<ToDoItemsListDTO, AddToDoItemListCommand>();
            CreateMap<ToDoItemsListDTO, RemoveToDoItemListCommand>();
            CreateMap<ToDoItemsListDTO, UpdateToDoItemListCommand>();
            CreateMap<ToDoItemsListDTO, GetToDoItemListQuery>();
        }
    }
}
