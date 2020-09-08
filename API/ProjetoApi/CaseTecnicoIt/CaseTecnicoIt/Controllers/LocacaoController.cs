using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        private readonly IMediator _mediator;
        [HttpGet]
        public IEnumerable<Locacoes> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Locacoes
            {
                idLocacao = 2,
                idCliente=  2,
                dtLocacao = DateTime.Now.ToLongDateString()
            })
            .ToArray();
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> ListaClienteID(string id)
        {
            var response = await _mediator.Send(new ListaLocacoesporIDQuery(id));

            if (response.HasMessages)
            {
                return BadRequest(response.Errors);
            }


            return Ok(response.Result);
        }
    }
}
