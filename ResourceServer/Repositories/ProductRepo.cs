using Microsoft.EntityFrameworkCore;
using ResourceServer.DTO.Requests;
using ResourceServer.Models;

namespace ResourceServer.Repositories
{
    public class ProductRepo : IProductRepo
    {
        private readonly ApplicationContext context;
        public ProductRepo(ApplicationContext context) 
        {
            this.context = context;
        }
        public async Task<Product> CreateAsync(CreateProductRequest productRequest)
        {
            if(productRequest == null)
            {
                throw new ArgumentNullException("CreateAsync parameter is null");
            }
            Product product = new Product()
            {
                Name = productRequest.Name,
                Price = productRequest.Price,
                Description = productRequest.Description,
                SupplierId = productRequest.SupplierId,
            };

            await context.Products.AddAsync(product);
            await context.SaveChangesAsync();
            return product;
        }

        public async Task DeleteAsync(int id)
        {
            Product product = await context.Products.FirstAsync(x => x.Id == id);

            context.Products.Remove(product);
            await context.SaveChangesAsync();
        }

        public async Task<List<Product>> GetAllAsync()
        {
            List<Product> products = await context.Products.ToListAsync();
            return products;
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            Product product = await context.Products.FirstAsync(p => p.Id == id);
            return product;
        }

        public async Task UpdateAsync(UpdateProductRequest updateProduct)
        {
            if(updateProduct == null)
            {
                throw new ArgumentNullException("Update product patameter is null");
            }

            Product product = await context.Products.FirstAsync(p => p.Id == updateProduct.Id);

            product.Name = updateProduct.Name;
            product.Price = updateProduct.Price;
            product.Description = updateProduct.Description;
            product.SupplierId= updateProduct.SupplierId;

            context.Products.Update(product);
            await context.SaveChangesAsync();
        }
    }
}
