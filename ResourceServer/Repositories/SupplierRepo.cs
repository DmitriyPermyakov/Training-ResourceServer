using ResourceServer.Models;

namespace ResourceServer.Repositories
{
    public class SupplierRepo : ISupplierRepo
    {
        private readonly ApplicationContext context;
        public SupplierRepo(ApplicationContext context)
        {
            this.context = context;
        }
        public Task CreateAsync(Supplier supplier)
        {
            
        }

        public Task DeleteAsync(Supplier supplier)
        {
            throw new NotImplementedException();
        }

        public Task<List<Supplier>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Supplier> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Supplier supplier)
        {
            throw new NotImplementedException();
        }
    }
}
