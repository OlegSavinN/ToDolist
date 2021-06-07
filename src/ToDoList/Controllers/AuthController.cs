using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ToDoList.Application.Queries.GetToken;
using ToDoList.DTO;
using AutoMapper;
using ToDoList.Filters;

namespace ToDoList.Controllers
{
    [ApiController]
    [SetIdFilter]
    [Route("Auth")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public AuthController(
            IMediator mediator,
            IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<AuthResultDTO> GetToken(
            [FromBody] AuthRequestDTO authRequestDTO)
        {
            var query = _mapper.Map<GetTokenQuery>(authRequestDTO);
            var token = new AuthResultDTO();
            token.AccessToken = await _mediator.Send(query);
            return token;
        }
    }
}
