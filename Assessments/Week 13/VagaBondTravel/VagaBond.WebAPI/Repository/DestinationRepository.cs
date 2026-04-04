using Microsoft.EntityFrameworkCore;
using VagaBond.WebAPI.Data;
using VagaBond.WebAPI.Model;

namespace VagaBond.WebAPI.Repository
{
    public class DestinationRepository : IDestinationRepository
    {
        private readonly VagaBondWebAPIContext _context;

        public DestinationRepository(VagaBondWebAPIContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Destination>> GetAllAsync()
        {
            return await _context.Destination.ToListAsync();
        }

        public async Task<Destination?> GetByIdAsync(int id)
        {
            return await _context.Destination.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddAsync(Destination destination)
        {
            await _context.Destination.AddAsync(destination);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Destination destination)
        {
            var existing = await _context.Destination.FindAsync(destination.Id);

            if (existing == null)
                throw new Exception("Destination not found");

            _context.Entry(existing).CurrentValues.SetValues(destination);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var destination = await _context.Destination.FindAsync(id);

            if (destination == null)
                throw new Exception("Destination not found");

            _context.Destination.Remove(destination);
            await _context.SaveChangesAsync();
        }
    }
}
