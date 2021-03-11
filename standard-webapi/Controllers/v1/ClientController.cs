using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using standard_webapi.Business;
using standard_webapi.Models;

namespace standard_webapi.Controllers.v1
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IClientBusiness _business;
        
        public ClientController(IClientBusiness business)
        {
            _business = business;
        }

        [HttpGet]
        public async Task<IActionResult> FindAll()
        {
            var result = await _business.FindAll();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Register(Client client)
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