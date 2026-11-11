using DepBoard.Application.Interfaces;
using DepBoard.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DepBoard.Application.Services
{
    public class NotasServices
    {
        public IDbContext _context;

        public NotasServices(IDbContext context)
        {
            this._context = context;
        }

        public async Task<ICollection<Nota>> GetNotas()
        {
            return await _context.Notas.ToListAsync();
        }

        public async Task<ICollection<Nota>> GetByPerletivo(string perletivo)
        {
            return await _context.Notas
                .Where(d => d.Perletivo == perletivo)
                .ToListAsync();
        }
    }
}
