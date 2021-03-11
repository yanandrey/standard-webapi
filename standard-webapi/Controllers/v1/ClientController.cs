using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using standard_webapi.Business;
using standard_webapi.Data.DTOs;

namespace standard_webapi.Controllers.v1
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IClientBusiness _business;
        private readonly IMapper _mapper;
        
        public ClientController(IClientBusiness business, IMapper mapper)
        {
            _business = business;
            _mapper = mapper;
        }

        /// <summary>
        /// It lists all clients.
        /// </summary>
        /// <returns>List with all clients.</returns>
        /// <response code="200"> When customers are listed. </response>
        /// <response code="500"> When there is an error when listing clients. </response>
        [HttpGet]
        [ProducesResponseType(typeof(ClientDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<IActionResult> FindAll()
        {
            var result = await _business.FindAll();
            return Ok(_mapper.Map<List<ClientDTO>>(result));
        }

        /// <summary>
        /// It registers a new client.
        /// </summary>
        /// <param name="client">Client to be registered.</param>
        /// <returns>Registered client.</returns>
        /// <response code="201"> When a client is registered. </response>
        /// <response code="400"> When a required field has not been entered or reported incorrectly.</response>
        /// <response code="500"> When there is an error when registering a client. </response>
        [HttpPost]
        [ProducesResponseType(typeof(ClientDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<IActionResult> Register(ClientDTO client)
        {
            if (!ModelState.IsValid) return null;

            await _business.Register(client);
            return Ok(client);
        }
    }
}