using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaseTecnicoIt.Application.Commands.Insert;
using CaseTecnicoIt.Application.Commands.Update;
using CaseTecnicoIt.Application.Queries.ListaFilmes;
using CaseTecnicoIt.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CaseTecnicoIt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmesController : ControllerBase
    {
        public FilmesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        private readonly IMediator _mediator;

        [HttpPost]
        [Route("/ListaFIlmeID")]
        public async Task<IActionResult> ListaFIlmeID(string id)
        {
            var response = await _mediator.Send(new ListaFilmesporIdQuery(id));

            if (response.HasMessages)
            {
                return BadRequest(response.Errors);
            }


            return Ok(response.Result);
        }

        [HttpPost]
        [Route("/criarFilmes")]
        public async Task<IActionResult> criarFilmes(string filme, string anolancamento)
        {
            var response = await _mediator.Send(new InsertFilme(filme,anolancamento));
            if (response.HasMessages)
            {
                return BadRequest(response.Errors);
            }
            return Ok(response.Result);
        }

        [HttpPost]
        [Route("/AtualizarFilmes")]
        public async Task<IActionResult> AtualizarCliente(int id, string cliente, string anoLancamento)
        {
            var response = await _mediator.Send(new UpdateFilme(id, cliente, anoLancamento));
            if (response.HasMessages)
            {
                return BadRequest(response.Errors);
            }
            return Ok(response.Result);
        }

    }
}
