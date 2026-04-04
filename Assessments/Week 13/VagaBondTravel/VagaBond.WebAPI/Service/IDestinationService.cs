using VagaBond.WebAPI.Model;

namespace VagaBond.WebAPI.Service
{
    public interface IDestinationService
    {
        public Task<IEnumerable<Destination>> GetAllAsync();
        public Task<Destination> GetByIdAsync(int id);
        public Task AddAsync(Destination destination);
        public Task UpdateAsync(Destination destination);
        public Task DeleteAsync(int id);
    }
}
