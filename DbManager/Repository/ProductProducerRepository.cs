using DbManager;
using DbManager.RepositoryInterfaces;
using DbModel;
using DbModel.Products;
using DbModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbManager.Repository
{
    public class ProductProducerRepository : IRepository<Producer,ProducerViewModel>
    {
        ProductProducerDbContext _context;
        public ProductProducerRepository()
        {
            _context = new ProductProducerDbContext();
        }
        public ProductProducerRepository(ProductProducerDbContext dbContext)
        {
            _context = dbContext;
        }
        public void Create(Producer entity)
        {
            _context.Producers.Add(entity);
        }

        public void Delete(int Id)
        {
            var entity = Read(Id);
            _context.Producers.Remove(entity);
        }

       
        public async Task<IEnumerable<Producer>> GetAllAsync()
        {
            return await _context.Producers.ToListAsync();
        }

        public Producer Read(int Id)
        {
           return _context.Producers.Find(Id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Producer entity)
        {
            _context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
        }

  

        public IEnumerable<ProducerViewModel> ViewModelList()
        {
            var sourceList = _context.Producers.ToListAsync().Result;
            var result = new List<ProducerViewModel>();
            foreach (var item in sourceList)
            {
                result.Add(MarketMapper.Mapper.Map<Producer, ProducerViewModel>(item));
            }
            return result;

        }
    }
}
