using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using standard_webapi.Models;
using standard_webapi.Models.DataContext;

namespace standard_webapi.Business.Implementations
{
    public class ClientImplementation : IClientBusiness
    {
        private readonly Context _context;
        
        public ClientImplementation(Context context)
        {
            _context = context;
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

        public async Task<Client> Register(Client client)
        {
            await _context.AddAsync(client);
            await _context.SaveChangesAsync();
            return client;
        }
    }
}