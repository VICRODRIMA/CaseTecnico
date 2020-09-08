using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaseTecnicoIt.Application.Commands.Insert;
using CaseTecnicoIt.Application.Queries.ListaLocacoes;
using CaseTecnicoIt.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CaseTecnicoIt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocacaoController : ControllerBase
    {
        public LocacaoController(IMediator mediator)
        {
            _mediator = mediator;
        }
        private readonly IMediator _mediator;


        [HttpGet]
        [Route("ListaLocacaoID")]
        public async Task<IActionResult> ListaLocacaoID(string id)
        {
            var response = await _mediator.Send(new ListaLocacoesporIDQuery(id));

            if (response.HasMessages)
            {
                return BadRequest(response.Errors);
            }


            return Ok(response.Result);
        }

        [HttpPost]
        [Route("/CriarLocacoes")]
        public async Task<IActionResult> criarLocacoes(int idLocador, int idFilme, int idCliente, string dtDevolucao)
        {
            var response = await _mediator.Send(new InsertLocacao(idLocador,  idFilme,  idCliente,  dtDevolucao));
            if (response.HasMessages)
            {
                return BadRequest(response.Errors);
            }
            return Ok(response.Result);
        }
    }
}
