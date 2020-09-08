using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaseTecnicoIt.Application.Queries.ListaCliente;
using CaseTecnicoIt.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CaseTecnicoIt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IMediator _mediator;


        [HttpGet]
        public IEnumerable<Cliente> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Cliente
            {
                IdCliente = Guid.NewGuid(),
                nomeCliente = "sdfsdfsdf"
            })
            .ToArray();
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult>ListaClienteID(string id)
        {
            var response = await _mediator.Send(new ListaClienteporIdQuery(id));

            if (response.HasMessages)
            {
                return BadRequest(response.Errors);
            }


            return Ok(response.Result);
        }

        [HttpPost]
        [Route("/CriarCliente")]
        public async Task<IActionResult> CriarCliente(Cliente cliente)
        {
            var response = await _mediator.Send(new ListaClienteporIdQuery(cliente));

            if (response.HasMessages)
            {
                return BadRequest(response.Errors);
            }


            return Ok(response.Result);
        }



    }
}
