using DbManager;
using DbManager.RepositoryInterfaces;
using DbModel.Products;
using DbModel.ViewModel;
using DbModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbManager.Repository
{
    public class ProductRepository : IRepository<Product,ProductViewModel>
    {
        private ProductDbContext context;
        public ProductRepository()
        {
            context = new ProductDbContext();
        }
        public void Create(Product entity)
        {
            context.Products.Add(entity);
        }

        public void Delete(int Id)
        {
            var entity = Read(Id);
            context.Products.Remove(entity);
        }

  
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
             return await context.Products.ToListAsync();
        }

        public Product Read(int Id)
        {
            return context.Products.Find(Id);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Product entity)
        {
            context.Entry(entity).State = System.Data.Entity.EntityState.Modified;

        }

        public IEnumerable<ProductViewModel> ViewModelList()
        {
            var sourceList = context.Products.ToListAsync().Result;
            var result = new List<ProductViewModel>();
            foreach (var product in sourceList)
            {
                result.Add(MarketMapper.Mapper.Map<Product, ProductViewModel>(product));
            }
            return result;
        }
    }
}
