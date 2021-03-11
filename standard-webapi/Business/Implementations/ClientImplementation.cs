using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using standard_webapi.Data.DTOs;
using standard_webapi.Models;
using standard_webapi.Models.DataContext;

namespace standard_webapi.Business.Implementations
{
    public class ClientImplementation : IClientBusiness
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        
        public ClientImplementation(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        public async Task<List<Client>> FindAll()
        {
            return await _context
                .Clients
                .Include(c => c.Addresses)
                .AsSplitQuery()
                .Include(c => c.Contacts)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Client> Register(ClientDTO clientDto)
        {
            var client = _mapper.Map<ClientDTO, Client>(clientDto);
            await _context.AddAsync(client);
            await _context.SaveChangesAsync();
            return client;
        }
    }
}