using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbManager.RepositoryInterfaces;
using DbModel.Products;
using DbModel.ViewModel;

namespace DbManager.ProductGroupRepository
{
    public class ProductGroupRepository : IRepository<ProductGroup,ProductGroupViewModel>
    {
        private ProductGroupDbContext _context;

        public ProductGroupRepository()
        {
            _context = new ProductGroupDbContext();
        }
        public ProductGroupRepository(ProductGroupDbContext context)
        {
            _context = context;
        }

        public void Create(ProductGroup entity)
        {
            _context.ProductGroup.Add(entity);

        }

        public void Delete(int Id)
        {
            var entity = Read(Id);
            _context.ProductGroup.Remove(entity);
        }

        

        public ProductGroup Read(int Id)
        {
            return _context.ProductGroup.Find(Id);
        }

        public void Update(ProductGroup entity)
        {
            _context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
        }

        public IEnumerable<ProductGroup> GetAllGroups()
        {
            return _context.ProductGroup.ToList();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task<IEnumerable<ProductGroup>> GetAllAsync()
        {
          return  await _context.ProductGroup.ToListAsync();
        }

        public IEnumerable<ProductGroupViewModel> ViewModelList()
        {
            throw new NotImplementedException();
        }
    }
}
