using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using standard_webapi.Business;
using standard_webapi.Data.DTOs;
using standard_webapi.Models;

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

        [HttpGet]
        public async Task<IActionResult> FindAll()
        {
            var result = await _business.FindAll();
            return Ok(_mapper.Map<List<ClientDTO>>(result));
        }

        [HttpPost]
        public async Task<IActionResult> Register(ClientDTO client)
        {
            if (!ModelState.IsValid)
            {
                return null;
            }

            await _business.Register(client);
            return Ok(client);
        }
    }
}