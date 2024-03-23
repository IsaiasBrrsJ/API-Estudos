using Aluno.Application.Command.AtivarAlunoCommand;
using Aluno.Application.Command.CreateUserCommand;
using Aluno.Application.Command.InativarAlunoCommand;
using Aluno.Application.Queries.GetAlunoByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Aluno.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly IMediator _Mediator;

        public AlunoController(IMediator mediator)
        {
            _Mediator = mediator;
        }

        [HttpPost("PostAluno")]
        public async Task<IActionResult> PostAluno(CreateAlunoCommand command)
        {
            var result = await _Mediator.Send(command);

            var uri = new Uri("https://localhost:7051/api/Aluno/GetAluno/"+result);

            return Created(uri, result);
        }

        [HttpGet("GetAluno/{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var query = new GetAlunoByIdQuery();
            query.Id = id;

            var result = await _Mediator.Send(query);
            
            if(result is null)
                return NotFound();


            return Ok(result);
        }
        [HttpPatch("AtivarAluno/{id}")]
        public async Task<IActionResult> AtivarUser([FromRoute] int id)
        {
            var command = new AtivarAlunoCommand();
            command.Id = id;

           await _Mediator.Send(command);

            return NoContent();
        }
        [HttpPatch("InativarAluno/{id}")]
        public async Task<IActionResult> Inativar([FromRoute] int id)
        {
            var command = new InativarAlunoCommand();
            command.Id = id;

            await _Mediator.Send(command);

            return NoContent();
        }
    }
}
