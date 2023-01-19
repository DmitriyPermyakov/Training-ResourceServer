using ResourceServer.DTO.Requests;
using ResourceServer.Models;

namespace ResourceServer.Repositories
{
    public interface IProductRepo
    {
        public Task<List<Product>> GetAllAsync();
        public Task<Product> GetByIdAsync(int id);
        public Task<Product> CreateAsync(CreateProductRequest productRequest);
        public Task UpdateAsync(UpdateProductRequest product);
        public Task DeleteAsync(int id);
        

    }
}
