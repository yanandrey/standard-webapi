using System.Collections.Generic;
using System.Threading.Tasks;
using standard_webapi.Data.DTOs;
using standard_webapi.Models;

namespace standard_webapi.Business
{
    public interface IClientBusiness
    {
        Task<List<Client>> FindAll();

        Task<Client> Register(ClientDTO clientDto);
    }
}