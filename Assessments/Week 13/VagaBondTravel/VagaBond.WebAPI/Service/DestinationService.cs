using VagaBond.WebAPI.Model;
using VagaBond.WebAPI.Repository;

namespace VagaBond.WebAPI.Service
{
    public class DestinationService : IDestinationService
    {
        private readonly IDestinationRepository _repo;

        public DestinationService(IDestinationRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Destination>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<Destination> GetByIdAsync(int id)
        {
            return await _repo.GetByIdAsync(id);
        }

        public async Task AddAsync(Destination destination)
        {
            if (destination == null)
                throw new ArgumentNullException(nameof(destination));

            await _repo.AddAsync(destination);
        }

        public async Task UpdateAsync(Destination destination)
        {
            if (destination == null)
                throw new ArgumentNullException(nameof(destination));

            var existing = await _repo.GetByIdAsync(destination.Id);

            if (existing == null)
                throw new KeyNotFoundException("Destination not found");

            await _repo.UpdateAsync(destination);
        }

        public async Task DeleteAsync(int id)
        {
            var existing = await _repo.GetByIdAsync(id);

            if (existing == null)
                throw new KeyNotFoundException("Destination not found");

            await _repo.DeleteAsync(id);
        }
    }
}
