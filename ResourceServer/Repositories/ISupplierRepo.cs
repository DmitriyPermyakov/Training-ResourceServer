using ResourceServer.Models;

namespace ResourceServer.Repositories
{
    public interface ISupplierRepo
    {
        public Task<Supplier> GetByIdAsync(int id);
        public Task<List<Supplier>> GetAllAsync();
        public Task CreateAsync(Supplier supplier);
        public Task UpdateAsync(Supplier supplier);
        public Task DeleteAsync(Supplier supplier);

    }
}
