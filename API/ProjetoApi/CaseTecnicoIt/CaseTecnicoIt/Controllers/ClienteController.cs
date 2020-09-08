using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaseTecnicoIt.Application.Commands.Insert;
using CaseTecnicoIt.Application.Commands.Update;
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

        public ClienteController(IMediator mediator)
        {
            _mediator = mediator;
        }
        //[HttpGet]
        //public IEnumerable<Cliente> Get()
        //{
        //    var rng = new Random();
        //    return Enumerable.Range(1, 5).Select(index => new Cliente
        //    {
        //        nomeCliente = "sdfsdfsdf"
        //    })
        //    .ToArray();
        //}
        //[HttpGet]     
        //public async Task<IEnumerable <Cliente>> Get(string id)
        //{
        //    var response = await _mediator.Send(new ListaClienteQuery());

        //    if (response.HasMessages)
        //    {
        //        return (IEnumerable<Cliente>)BadRequest(response.Errors);
        //    }


        //    return Ok(response.Result);
        //}
        [HttpPost]
        [Route("/ListaClienteID")]
        public async Task<IActionResult> ListaClienteID(string id)
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
        public async Task<IActionResult> CriarCliente(string cliente)
        {
            var response = await _mediator.Send(new InsertCliente(cliente));
            if (response.HasMessages)
            {
                return BadRequest(response.Errors);
            }
            return Ok(response.Result);
        }

        [HttpPost]
        [Route("/AtualizarCliente")]
        public async Task<IActionResult> AtualizarCliente(int id, string cliente)
        {
            var response = await _mediator.Send(new UpdateCliente(id, cliente));
            if (response.HasMessages)
            {
                return BadRequest(response.Errors);
            }
            return Ok(response.Result);
        }

    }
}
