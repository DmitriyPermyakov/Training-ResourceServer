using ResourceServer.DTO.Requests;
using ResourceServer.Models;

namespace ResourceServer.Repositories
{
    public interface ISupplierRepo
    {
        public Task<Supplier> GetByIdAsync(int id);
        public Task<List<Supplier>> GetAllAsync();
        public Task<int> CreateAsync(CreateSupplierRequest supplierRequest);
        public Task UpdateAsync(UpdateSupplierRequest updateSupplierRequest);
        public Task DeleteAsync(int id);

    }
}
