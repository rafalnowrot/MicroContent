using MicroContent.Products.Domain.Models;
using MicroContent.Products.Domain.Interface;

namespace MicroContent.Products.Infrastructure.Services;

    internal class ProductsService : IRepository<Product>
    {
        private readonly ProductsDbContext _context;

        public ProductsService(ProductsDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return _context.Products.AsEnumerable();
            throw new NotImplementedException();
        }

        public async Task Save(Product request)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(Product request)
        {
            throw new NotImplementedException();
        }

        public async Task Update(Product request)
        {
            throw new NotImplementedException();
        }

        public async Task GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
