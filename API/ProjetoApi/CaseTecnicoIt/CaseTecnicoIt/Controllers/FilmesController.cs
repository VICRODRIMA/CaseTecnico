using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        private readonly IMediator _mediator;
        [HttpGet]
        public IEnumerable<Filmes> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Filmes
            {
                idFilme = Guid.NewGuid(),
                nomeFilme = "NomeFilme",
                anoLancamento = DateTime.Now.Year.ToString()
            })
            .ToArray();
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> ListaClienteID(string id)
        {
            var response = await _mediator.Send(new ListaFilmesporIdQuery(id));

            if (response.HasMessages)
            {
                return BadRequest(response.Errors);
            }


            return Ok(response.Result);
        }
    }
}
