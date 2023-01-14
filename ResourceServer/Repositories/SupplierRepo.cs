using Microsoft.EntityFrameworkCore;
using ResourceServer.DTO.Requests;
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
        public async Task<int> CreateAsync(CreateSupplierRequest supplierRequest)
        {
            if(supplierRequest == null)
            {
                throw new ArgumentNullException("supplier request parameter is null");
            }

            Address address = new Address
            {
                City = supplierRequest.City,
                Street = supplierRequest.Street,
                Building = supplierRequest.Building,
            };

            Supplier supplier = new Supplier
            {
                Name = supplierRequest.SupplierName,
                Address = address,
            };

            context.Suppliers.Add(supplier);            
            await context.SaveChangesAsync();

            return supplier.Id;
        }

        public async Task DeleteAsync(int id)
        {
            Supplier? supplier = await context.Suppliers.FirstAsync(x => x.Id == id);
            context.Suppliers.Remove(supplier);
            await context.SaveChangesAsync();
        }

        public async Task<List<Supplier>> GetAllAsync()
        {
            List<Supplier> list = await context.Suppliers.Include(s => s.Address).ToListAsync();
            return list;
        }

        public async Task<Supplier> GetByIdAsync(int id)
        {
            Supplier? supplier = await context.Suppliers.Include(s => s.Address).FirstAsync(x => x.Id == id);
            return supplier;
        }

        public async Task UpdateAsync(UpdateSupplierRequest updateRequest)
        {
            if(updateRequest == null)
            {
                throw new ArgumentNullException("Updated request parameter is null");
            }

            Supplier supplier = await context.Suppliers.Include(s => s.Address).FirstAsync(x => x.Id == updateRequest.Id);
            supplier.Name = updateRequest.SupplierName;
            supplier.Address.City = updateRequest.City;
            supplier.Address.Street = updateRequest.Street;
            supplier.Address.Building= updateRequest.Building;

            context.Suppliers.Update(supplier);
            await context.SaveChangesAsync();
        }
    }
}
