using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CaseTecnicoIt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocadoraController : ControllerBase
    {
        public LocadoraController(IMediator mediator)
        {
            _mediator = mediator;
        }
        private readonly IMediator _mediator;


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
